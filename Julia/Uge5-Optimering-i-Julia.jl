########################    OPGAVE 5.1 del 1    ########################
using JuMP
using HiGHS

IC = Model(HiGHS.Optimizer)
set_optimizer_attribute(IC, "log_to_console", false)

#Definierer variables:
@variable(IC,xA>=0, Int)
@variable(IC,xB>=0, Int)

# objectivefunktion Definieres hvor vi max
@objective(IC, Max, 4*xA+6*xB)

#Begrænsninger tilføjes
@constraint(IC, c1, 2*xA <= 14)
@constraint(IC, c2, 3*xB <= 15)
@constraint(IC, c3, 4*xA+3*xB <= 36)

#Der printes firmaets problem matematisk
print(IC)

#Den optimale løsning beregnes
optimize!(IC)

#skrives at det beregnes
println("Termination status: $(termination_status(IC))")

#Hvis der er en løsning, udskrives løsningen ellers skrives der ingen løsning
if termination_status(IC) == MOI.OPTIMAL
    println("Optimal objective value: $(objective_value(IC))")
    println("xA: ",value(xA))
    println("xB: ",value(xB))
else
    println("No optimal solution available")
end

# ALTERNATIVE SUMMARY
#solution_summary(IC; verbose = true)

########################    OPGAVE 5.1 del 2    ########################

using JuMP
using HiGHS

# PARAMETERS
Chairs = ["A", "B"]
C=length(Chairs)

#Antal Begrænsninger
ProductionLines = ["1","2","3"]
P=length(ProductionLines)

#Profit
Profit = [4 6]

#Det som Begrænsninger er begrænset af
Capacity = [14,15,36]

RecourseUsage =
    [
        2 0;
        0 3;
        4 3
    ]

# MODEL
IC = Model(HiGHS.Optimizer)
set_optimizer_attribute(IC, "log_to_console", false)

#Definierer variables efter hvor mange variabler vi har
@variable(IC,x[1:C]>=0, Int)

# objectivefunktion Definieres hvor vi her fx max.
@objective(IC, Max, sum( Profit[c]*x[c] for c=1:C))

#Begrænsninger tilføjes
@constraint(IC, [p=1:P], sum( RecourseUsage[p,c]*x[c] for c=1:C) <= Capacity[p])

#Der printes firmaets problem matematisk
print(IC)

#Den optimale løsning beregnes
solution = optimize!(IC)
println("Termination status: $(termination_status(IC))")

#Hvis der er en løsning, udskrives løsningen ellers skrives der ingen løsning
if termination_status(IC) == MOI.OPTIMAL
    println("Optimal objective value: $(objective_value(IC))")
    for c=1:C
        println("x[", Chairs[c], "] : ",value(x[c]))
    end
else
    println("No optimal solution available")
end

########################    OPGAVE 5.1 del 3    ########################

using JuMP
using HiGHS

# PARAMETERS
Chairs = ["A" "B" "C" "D" "E" "F" "G" "H" "I" "J"]
C=length(Chairs)

#Antal Begrænsninger
ProductionLines = [1 2 3 4 5]
P=length(ProductionLines)

#Profit
Profit = [6 5 9 5 6 3 4 7 4 3]

#Det som Begrænsninger er begrænset af
Capacity = [47 19 36 13 46]

RecourseUsage =
    [
        6 4 2 3 1 10 2 9 3 5;
        5 6 1 1 7 2 9 1 8 6;
        8 10 7 2 9 6 9 6 5 6;
        8 4 8 10 5 4 1 5 3 5;
        1 4 7 2 4 1 2 3 10 1;
    ]

# MODEL
IC = Model(HiGHS.Optimizer)
set_optimizer_attribute(IC, "log_to_console", false)

#Definierer variables efter hvor mange variabler vi har
@variable(IC,x[1:C]>=0, Int)

# objectivefunktion Definieres hvor vi her fx max.
@objective(IC, Max, sum( Profit[c]*x[c] for c=1:C))

#Begrænsninger tilføjes
@constraint(IC, [p=1:P], sum( RecourseUsage[p,c]*x[c] for c=1:C) <= Capacity[p])

#Der printes firmaets problem matematisk
print(IC)

#Den optimale løsning beregnes
solution = optimize!(IC)
println("Termination status: $(termination_status(IC))")

#Hvis der er en løsning, udskrives løsningen ellers skrives der ingen løsning
if termination_status(IC) == MOI.OPTIMAL
    println("Optimal objective value: $(objective_value(IC))")
    for c=1:C
        println("x[", Chairs[c], "] : ",value(x[c]))
    end
else
    println("No optimal solution available")
end

########################    OPGAVE 5.2    ########################

using JuMP
using HiGHS

# PARAMETERS
Children=[1 2 3 4 5]
C=length(Children)
Jobs=[1 2 3 4 5]
J=length(Jobs)
 
Ønske=[
    1 3 2 5 5;
    5 2 1 1 2;
    1 5 1 1 1;
    4 5 4 4 4;
    3 5 3 5 3
]

TidsKrævet=[
    1 2 1 4 4;
    6 2 4 2 2;
    3 3 2 4 4;
    1 1 4 4 2;
    7 2 2 3 1
]
Tidbegrænsning = 3

#************************************************************************
# MODEL
CJ = Model(HiGHS.Optimizer)
set_optimizer_attribute(CJ, "log_to_console", false)

#Definierer variables efter hvor mange variabler vi har
@variable(CJ,x[j=1:J,c=1:C], Bin) 

# objectivefunktion Definieres hvor vi her fx max.
@objective(CJ, Max, sum( Ønske[j,c]*x[j,c] for j=1:J,c=1:C ) )

#Begrænsninger
# One job pr. child
@constraint(CJ, [c=1:C],
            sum( x[j,c] for j=1:J) == 1
)

# One child pr. job
@constraint(CJ, [j=1:J],
            sum( x[j,c] for c=1:C) == 1
)

# timelimit pr. job pr. child
@constraint(CJ, [j=1:J],
            sum( TidsKrævet[j,c]*x[j,c] for c=1:J) <= Tidbegrænsning
            )
#Der printes firmaets problem matematisk
print(CJ)

#************************************************************************
# SOLVE
#Den optimale løsning beregnes
solution = optimize!(CJ)
println("Termination status: $(termination_status(CJ))")
#************************************************************************

#************************************************************************
#Hvis der er en løsning, udskrives løsningen ellers skrives der ingen løsning
if termination_status(CJ) == MOI.OPTIMAL
    println("Optimal værdi af objektfunktionen: $(objective_value(CJ))")
    for c=1:C
        for j=1:J
            if value(x[j,c])>0.999
                println("Barn: ", c, " skal udføre job: ", j)
            end
        end
    end
else
    println("No optimal solution available")
end
#************************************************************************



########################    OPGAVE 5.3    ########################


using JuMP
using HiGHS

#************************************************************************
# PARAMETERS
Fabrikker = ["A", "B", "C", "D"]            # mængden af fabrikker
F = length(Fabrikker)                       # F er størrelsen på mængden af fabrikker
Grossister = ["G1", "G2", "G3", "G4"]       # mængdena af grossister
G = length(Grossister)                      # G er størrelsen på mængden af grossister
Efterspørgsel = [9, 11, 10, 10]             # efterspørgsel pr. grossist           
Beholdning = [12, 12, 8, 8]                 # beholdning pr. fabrik
Cost = [ 2  4  10  9;                       # omkostning af transport fra fabrik j (række) til grossist i (søjle)
         4  1  9 10;
        10  8   2  4;
         9  9   2  2;
]
#************************************************************************

#************************************************************************
# MODEL
T=Model(HiGHS.Optimizer)

@variable(T, x[1:F, 1:G] >= 0 )
#@variable(T, y[1:F] >= 0) #Del c

#Vi ønsker at minimere transportomkostninger, derfor min:
@objective(T, Min, sum( Cost[f,g] * x[f,g] for f=1:F, g=1:G)) # Minimer omkostninger
#@objective(T, Min, sum( Cost[f,g] * x[f,g] for f=1:F, g=1:G) + sum( Cost[f,1] * y[f]  for f=1:F)) #Del C

#Begrænsninger indsættes: Dette kræves at summen af hver rækker skal være mindre eller lig med beholdningen!
@constraint(T, [f=1:F],sum(x[f,g] for g=1:G) <= Beholdning[f]) # Kapacitetsbegrænsning

#Det samme, bare for hver søjler skal være større eller lig med efterspørgslen!
@constraint(T, [g=1:G],sum(x[f,g] for f=1:F) >= Efterspørgsel[g]) # Udfyld efterspørgslen

#@constraint(T, sum(y[1:F]) >= 4) #Del C

print(T) # print modellen for screening (giver kun mening for små modeller)
#************************************************************************

#************************************************************************
# SOLVE
optimize!(T)
println("Termination status: $(termination_status(T))")
#************************************************************************

#************************************************************************
if termination_status(T) == MOI.OPTIMAL
    println("Minimal omkostning: $(objective_value(T))")
    println("Løsning:")
    println(display(value.(x)))
    for f = 1:F
      for g in 1:G
        if value(x[f,g]) > 0.001
          println(" Fra fabrik $(Fabrikker[f]) til grossist $(Grossister[g]): $(value(x[f,g]))")
        end
      end
    end
else
    println("No optimal solution available")
end
#************************************************************************


#************************************************************************
## Opgave C!
# Hvis efterspørgslen øges et sted uden at øge produktionen, har problemet ingen løsning.
## Det er oplagt billigst at producere på fabrik A til grossist 1. Alternativt kan man tilføjge
# @variable(T, y[1:F] >= 0)
# @constraint(T, sum(y[1:F]) >= 4)
## og ændre
# @objective(T, Min, sum( Cost[f,g] * x[f,g] for f=1:F, g=1:G) + sum( Cost[f,1] * y[f]  for f=1:F))
## og tjekke
# display(value.(y))
# display(value.(x))


########################    OPGAVE 5.4    ########################
# Grossister!

# Intro definitions
using JuMP
using HiGHS
#************************************************************************
#************************************************************************

# PARAMETERS
C=6 # no of customers
#Definierer en matrix
coord = zeros(C,2)

coord[1,1]=0; coord[1,2]=0
coord[2,1]=104; coord[2,2]=19
coord[3,1]=370; coord[3,2]=305
coord[4,1]=651; coord[4,2]=221
coord[5,1]=112; coord[5,2]=121
coord[6,1]=134; coord[6,2]=515

Distance = zeros(Float64,C,C)
for c1 in 1:C
    for c2 in 1:C
        Distance[c1,c2]= sqrt( (coord[c1,1]-coord[c2,1])^2 + (coord[c1,2]-coord[c2,2])^2 )
    end
end

#Viser distance matrix: Hvilket ligner TSP!
display(Distance)

# MODEL
TSP = Model(HiGHS.Optimizer)

@variable(TSP, x[1:C,1:C],Bin)
for c1 in 1:C
    fix(x[c1,c1],0; force = true)
end


# Minimize TSP distance
@objective(TSP, Min, sum(Distance[c1,c2]*x[c1,c2] for c1=1:C, c2=1:C))
# you enter all cities
@constraint(TSP, city_enter_con[c1=1:C], sum(x[c2,c1] for c2=1:C)==1)
# you exit all cities
@constraint(TSP, city_exit_con[c1=1:C], sum(x[c1,c2] for c2=1:C)==1)

using Combinatorics
for S in 2:C-1  # Iterating over the size of the subsets
    for subset in combinations(1:C, S)
        @constraint(TSP, sum(x[i,j] for i in subset for j in subset) <= S - 1)
    end
end

## Alternative implementation
# @variable(TSP, u[1:C] >= 0)

# counter constraint
# @constraint(TSP, counter_con[c1=1:C,c2=2:C,c1!=c2], u[c1] + 1 <= u[c2] + C*(1-x[c1,c2]))


# SOLVE
optimize!(TSP)
println("Termination status: $(termination_status(TSP))")

println("objective = $(objective_value(TSP))")
println("Solve time: $(solve_time(TSP))")
println(round.(Int8,value.(x)))
#******************************************