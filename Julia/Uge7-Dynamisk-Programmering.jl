########################    OPGAVE 7.2    ########################
#************************************************************************
# Shortest Route Problem
using JuMP,HiGHS
#************************************************************************

#************************************************************************
# PARAMETERS
Weights = Dict(("A", "B") => 2, ("A", "C") => 4, ("A", "D") => 3, 
               ("B", "E") => 7, ("B", "F") => 4, ("B", "G") => 6, 
               ("C", "E") => 3, ("C", "F") => 2, ("C", "G") => 4, 
               ("D", "E") => 4, ("D", "F") => 1, ("D", "G") => 5,
               ("E", "H") => 1, ("E", "I") => 4, ("F", "H") => 6, 
               ("F", "I") => 3, ("G", "H") => 3, ("G", "I") => 3,
               ("H", "J") => 3, ("I", "J") => 4
)
Edges = collect(keys(Weights))
Nodes = collect(Set(node for edge in Edges for node in edge))
N = length(Nodes)
#Startpunkt:
Source = "A"
#Slutpunkt:
Destination = "J"
#************************************************************************


#************************************************************************
# MODEL
SR = Model(HiGHS.Optimizer)

@variable(SR, x[Edges], Bin)

# Minimize cost
@objective(SR, Min, sum( Weights[edge]*x[edge] for edge in Edges ) )

# Constraints
for node in Nodes
    if node == Source  # Make sure that the source node is used
        @constraint(SR, sum( x[edge] for edge in Edges if edge[1] == Source ) == 1)
    elseif node == Destination # Make sure that the destination node is used
        @constraint(SR, sum( x[edge] for edge in Edges if edge[2] == Destination ) == 1)
    else  # Make sure that if any other edge is used, then you both enter and leave
        @constraint(SR,
            sum( x[edge] for edge in Edges if node == edge[1] )  -  # outflow
                sum( x[edge] for edge in Edges if node == edge[2] ) # inflow
             == 0
            )
    end
end
#************************************************************************

#************************************************************************
# SOLVE
solution = optimize!(SR)
println("Termination status: $(termination_status(SR))")
#************************************************************************

#************************************************************************
if termination_status(SR) == MOI.OPTIMAL
    println("Optimal værdi af objektfunktionen: $(objective_value(SR))")
    print("Optimal rute: ", Source)

    let working_node = Source
        while working_node != Destination
            next_edge = findfirst(
                edge -> value(x[edge])>0.999 && edge[1] == working_node,
                Edges
                )
            if next_edge !== nothing
                working_node = Edges[next_edge][2]
                print(" -> ", working_node)
            end
        end
    end
else
    println("No optimal solution available")
end

println()


########################    OPGAVE 7.3    ########################

#************************************************************************
# Lot size with Dynamic Programming as Shortest Route
# Fixed Holding Capacity, and Holding Costs
using JuMP,HiGHS
#************************************************************************
#************************************************************************
# PARAMETERS (800 = 8! så tallene skal ganges med 100)
HoldingCapacity = 8
Demands = [5,6,3,4]
HoldingCost = 200 #lageromkostning 200 kr per enhed
OrderCost = 1500 #produktionsomkostninger er 150.000 (1500*100)
d = length(Demands)

# Weight specification for shortest route program
Weights = Dict(("P1", "P2L$j") => OrderCost + HoldingCost * j for j in 0:HoldingCapacity)
for Stage in 2:d-1
    for j in 0:Demands[Stage]-1
        for i in 0:HoldingCapacity
            Weights[("P$(Stage)L$j","P$(Stage+1)L$i")] = HoldingCost * i + OrderCost
        end
    end
    for j in Demands[Stage]:HoldingCapacity
        for i in 0:j-Demands[Stage]
            Weights[("P$(Stage)L$j","P$(Stage+1)L$i")] = HoldingCost * i
        end
        for i in j+1-Demands[Stage]:HoldingCapacity
            Weights[("P$(Stage)L$j","P$(Stage+1)L$i")] = HoldingCost * i + OrderCost
        end
    end
end
for j in 0:Demands[d]-1
    Weights[("P$(d)L$j","P$(d+1)")] = OrderCost
end
Weights[("P$(d)L$(Demands[d])","P$(d+1)")] = 0
for j in Demands[d]+1:10
    Weights[("P$(d)L$j","P$(d+1)")] = OrderCost * 1000
end

Edges = collect(keys(Weights))
Nodes = collect(Set(node for edge in Edges for node in edge))
N = length(Nodes)
Source = "P1"
Destination = "P$(d+1)"

#************************************************************************

#************************************************************************
# MODEL
SR = Model(HiGHS.Optimizer)

@variable(SR, x[Edges], Bin)

# Minimize cost
@objective(SR, Min, sum( Weights[edge]*x[edge] for edge in Edges ) )

# Constraints
for node in Nodes
    if node == Source  # Make sure that the source node is used
        @constraint(SR, sum( x[edge] for edge in Edges if edge[1] == Source ) == 1)
    elseif node == Destination # Make sure that the destination node is used
        @constraint(SR, sum( x[edge] for edge in Edges if edge[2] == Destination ) == 1)
    else  # Make sure that if any other edge is used, then you both enter and leave
        @constraint(SR,
            sum( x[edge] for edge in Edges if node == edge[1] )  -  # outflow
                sum( x[edge] for edge in Edges if node == edge[2] ) # inflow
             == 0
            )
    end
end
#************************************************************************

#************************************************************************
# SOLVE
solution = optimize!(SR)
println("Termination status: $(termination_status(SR))")
#************************************************************************

#************************************************************************
if termination_status(SR) == MOI.OPTIMAL
    println("Optimal værdi af objektfunktionen: $(objective_value(SR))")
    print("Optimal rute: ", Source)

    let working_node = Source
        while working_node != Destination
            next_edge = findfirst(
                edge -> value(x[edge])>0.999 && edge[1] == working_node, Edges
                )
            if next_edge !== nothing
                working_node = Edges[next_edge][2]
                print(" -> ", working_node)
            end
        end
    end
else
    println("No optimal solution available")
end

println()

