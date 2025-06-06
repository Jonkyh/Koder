
# opgave 1

rm(list=ls()) 
#install.packages("AER") 
library(AER) 
data(Grunfeld) 
View(Grunfeld) 
summary(Grunfeld) 

Gr <- head(Grunfeld,-40) # drop last 2 firms (fjerne sidste 40 observationer) 
Gr$firm <- factor(Gr$firm) # drop factor levels - vi konverterer dataene til 
#kategorisk data for sikkerhedsskyld 
View(Gr) 

# 1.1

interaction.plot(Gr$year,Gr$firm,log(Gr$invest),ylab = "Log(invest)",xlab = "Year",
                 col = 1:9, lty = 1:9,lwd = 2)



# 1.2
fit <- lm(log(invest)~year+firm,Gr) 
summary(fit) 

interaction.plot(Gr$year,Gr$firm,fitted(fit),ylab = "lm(Log(invest))",xlab = "Year",
                 col = 1:9, lty = 1:9,lwd = 2)

#Vi udskriver summary(fit) med 10 decimaler, så vi kan udregne log(invest) for 
# Chrysler i 1944 med mere nøjagtige tal: 
summaryfit <- summary(fit) 
printCoefmat(summaryfit$coefficients, digits = 10) 
fitted(fit) 

##Finder data, der er Gr$year == 1944 & Gr$firm == "Chrysler" 
(data_nummer<- which(Gr$year == 1944 & Gr$firm == "Chrysler")) 
## Vi finder  prædikterede værdi ved data=70 
fitted(fit)[data_nummer]

# 1.3
rf <- residuals(fit)
with(Gr, interaction.plot(year, firm, rf,
                          xlab = "Year", #Overskriften på x-aksen
                          ylab = "Residuals", #overskriften på y-aksen
                          main = "Interaction Plot of Residuals", #titel
                          col = 1:9,#Tilføjer farver
                          lty = 1:9,
                          lwd = 1.5)) 

with(Gr,abline(lm(rf~year), col="red"),xaxp = c(1935,1953,1))

# 1.4
fitx <- lm(log(invest)~factor(year)+firm,Gr)
summary(fitx)
#Igen finder vi log(invest) for Chrysler i 1944:
fitted(fitx)[70]

# 1.5
fit <- lm(log(invest)~year+firm,Gr)
fitx <- lm(log(invest)~factor(year)+firm,Gr)
anova(fit,fitx)
anova(fit)
anova(fitx)


# 1.6
qqnorm(residuals(fitx), main = "Q-Q residuals")
qqline(residuals(fitx))
residualPlots(fitx, terms = ~ . - Gr$year)

#middelværdi og varians af residualerne for firm
Gr$firm <- factor(Gr$firm)
firms <- levels(Gr$firm); firms
mean_residuals <- sapply(firms, function(firm) mean(fitx$residuals[Gr$firm == firm]))
var_residuals <- sapply(firms, function(firm) var(fitx$residuals[Gr$firm == firm]))
matrix <- cbind(mean_residuals, var_residuals)
rownames(matrix) <- firms
colnames(matrix) <- c("Mean Residual", "Variance Residual")
print(matrix)

#middelværdi og varians af residualerne for year
Grunfeld$year <- factor(Grunfeld$year)
years <- levels(Grunfeld$year); years
mean_residuals_years <- sapply(years, function(year) mean(fitx$residuals[Gr$year == year]))
sd_residuals_years <- sapply(years, function(year) sd(fitx$residuals[Gr$year == year]))
matrix_years <- cbind(mean_residuals_years, sd_residuals_years)
rownames(matrix_years) <- years
colnames(matrix_years) <- c("Mean Residual", "Variance Residual")
print(matrix_years)

#  1.7
rx <- residuals(fitx)
plot(tail(rx,-1) ~ head(rx,-1), subset=tail(Gr$year,-1) > 1935)

# opgave 2
rm(list=ls()) 

# 2.1
#Variansmatricen SIGMA
N <- 10
rho <- .42
sigma2 <-1
Sigma <- diag(N)
Sigma <- sigma2 * rho^abs(row(Sigma)-col(Sigma))

#Designmatricen X
X <- cbind(1, 1:N)
VarbetaAR1 <- solve(t(X)%*%X)%*%t(X)%*%Sigma%*%X%*%solve(t(X)%*%X); VarbetaAR1
VarbetaStd <- sigma2*solve(t(X)%*%X); VarbetaStd 


# 2.3
VariansbetaAR1 <- solve(t(X) %*% solve(Sigma) %*% X); VariansbetaAR1

# 2.4
library(mvtnorm)
Sigma11 <- Sigma[-10, -10]
Sigma22 <- Sigma[10, 10]
Sigma12 <- Sigma[-10, 10]
Sigma21 <- Sigma[10, -10]
mu <- rep(0, N)
# Vi genererer Y med middelværdi 0 og kovariansmatrix lig Sigma
Y <- rmvnorm(1, mean = mu, sigma = Sigma)
BetinBetinget_varians <- Sigma22 - Sigma12 %*% solve(Sigma11) %*% Sigma21;
Betinget_variansget_middel <- Sigma21 %*% solve(Sigma11) %*% Y[-10]; Betinget_middel



#opgave 3

rm(list=ls())
library(AER)
data(Grunfeld)
Gr <- head(Grunfeld,-40) # drop last 2 firms
Gr$firm <- factor(Gr$firm) # drop factor levels
View(Gr)
#lineær model
fitx <- lm(log(invest)~factor(year) + firm, Gr)

# 3.1
expand_fitx <- lm(log(invest)~factor(year) + firm + log(value) + log(capital), Gr)
summary(expand_fitx)
summary(fitx)
expand_fitxfitted <- expand_fitx$fitted.values
fitxfitted <- fitx$fitted.values
RSS <- sum((log(Gr$invest)-expand_fitxfitted)^2); RSS
RSSr <- sum((log(Gr$invest)-fitxfitted)^2); RSSr
df <- expand_fitx$df.residual
dfr <- fitx$df.residual
n <- length(Gr$invest)

#F-teststørrelse
Fvalue <- ((RSSr-RSS)/(dfr-df))/(RSS/df); Fvalue
#p-værdi
pf(Fvalue, df1 = dfr-df, df2 = df, lower=FALSE)
#til sammenligning med facit output:
anova(fitx, expand_fitx)
#konfidensinterval for log(value)
confint(expand_fitx,level=0.95)["log(value)",]

# 3.2
vvfitx <- lm(log(invest)~factor(year) + firm*(log(value) + log(capital)), Gr)
drop1(vvfitx, test="F")
#alternativ
#vvfitx <- lm(log(invest)~factor(year) + firm + log(value) + log(capital) + firm:(log(value) + log(capital)), Gr)

# 3.3
rho <- .5
Psi <- diag(20)
Psi <- rho^abs(row(Psi)-col(Psi))
T0 <- t(backsolve(chol(Psi),diag(20)))

#check at:
zapsmall(T0 %*% Psi %*% t(T0))

#konstruer T
T <- kronecker(diag(9),T0)
fitvv <- lm(log(invest) ~ factor(year) + firm*(log(value) + log(capital)), Gr)
X1 <- model.matrix(fitvv)
Y <- log(Gr$invest)
TY <- T %*% Y
TX1 <- T %*% X1
serialfitvv <- lm(TY ~ TX1 - 1)
fit <- lm(log(invest) ~ factor(year) + firm*log(value) + log(capital), Gr)
X2 <- model.matrix(fit); X1
Y <- log(Gr$invest)
TY <- T %*% Y
TX2 <- T %*% X2
serialfit <- lm(TY ~ TX2 - 1)
anova(serialfit, serialfitvv)

#vi tjekker første søjle i designmatricerne
print(TX1[,1])
print(TX2[,1])

# 3.4
library(nlme)
glsmodel <- gls(log(invest)~factor(year) + firm*log(value) + log(capital), data = Gr,
                correlation = corAR1(0.5, form = ~ year | firm, fixed = TRUE))
glsmodelvv <- gls(log(invest)~factor(year) + firm*(log(value) + log(capital)), data = Gr,
                  correlation = corAR1(0.5, form = ~ year | firm, fixed = TRUE))
anova(glsmodel, glsmodelvv)


# Opgave 4
rm(list=ls())

# 4.1
#install.packages("Ecdat")
#install.packages("Ecfun")
library(Ecdat)
View(MCAS)
MCAS <- MCAS
plot(MCAS$percap, MCAS$totsc8, xlab="Income per capita", ylab="8th grade score")


# 4.2
boxTidwell(MCAS$totsc8~MCAS$percap, data=MCAS)
percap_boxtidwell <- MCAS$percap^(-1.1959)
plot(percap_boxtidwell, MCAS$totsc8,
     xlab="Income per capita efter box-tide-well", ylab="8th grade score")


# 4.3
library(MASS)
bc1_resultat <- boxcox(MCAS$totsc8 ~ percap_boxtidwell, lambda=seq(-2,5))

opt1_lambda <- bc1_resultat$x[which.max(bc1_resultat$y)]
totsc8_transformation1 <- (MCAS$totsc8 ^ opt1_lambda - 1) / opt1_lambda
hist(MCAS$totsc8)
hist(totsc8_transformation1)
plot(totsc8_transformation1 ~ percap_boxtidwell,
     xlab="income per capita efter box-tide-well", ylab="8th grade score transformeret",
     main = "Plot af transformeret 8th grade score 
     vs income per capita")

# 4.4
fit <- lm(totsc8 ~ . -code - municipa - district - totsc4, data = MCAS)


# 4.5
vif(fit)

# 4.6
#install.packages("ISwR")
library(Ecdat)
library(ISwR)


#Vi omdømmer fit i stedet for regr, så vi kan bruge Peter's kode:
fit <- lm(totsc8 ~ . -code - municipa - district - totsc4, data = MCAS)
fit.infl <- influence.measures(fit)
summary(fit.infl)

plot(fit, ask=FALSE) # use plot history 

# opgave 7
rm(list=ls())
# 7.1
library(Ecdat)
View(BudgetFood)
BF4 <- subset(BudgetFood, wfood > 0 & size==4)
BF4model <- glm(wfood~1, family=quasibinomial(), data = BF4)
summary(BF4model)
confint(BF4model)
confint.default(BF4model)
mu <- exp(coef(BF4model)) / (1 + exp(coef(BF4model))); mu
phi <- (1 /(summary(BF4model)$dispersion))-1; phi

# Beregn alpha og beta
alpha <- mu * phi
beta <- (1 - mu) * phi
alpha
beta
hist(BF4$wfood, freq=FALSE)
x <- seq(0, 1, length.out = 100)
curve(dbeta(x, alpha, beta), add=TRUE)

# 7.2
mu <- mean(BF4$wfood); mu
s2 <- var(BF4$wfood); phi <- ((mu*(1-mu)/s2)-1)
alpha <- mu*phi; alpha
beta <- phi*(1-mu); beta
mu <- mean(BF4$wfood)
psi <- summary(BF4model)$dispersion
var_y <- psi*mu*(1-mu)
n <- length(BF4$wfood)
se_y <- sqrt(var_y/n); se_y
se_mu <- (1/(mu-mu^2))*se_y; se_mu
library(car)
b0 <- coef(BF4model)
deltaMethod(BF4model, "b0", parameterNames = c("b0"))

# 7.3
#install.packages("betareg")
library(betareg)
BF4model2 <- betareg(wfood~1, data = BF4)
summary(BF4model2)

# 7.4
library(stats4)
y <- BF4$wfood
mll <- function(mu=0.5, phi=1){
  alpha <- mu * phi
  beta <- (1 - mu) * phi
  lh <- (-sum(dbeta(BF4$wfood, alpha, beta, log = TRUE)))
}
suppressWarnings(summary(mle(mll)))
mle_mu <- suppressWarnings(coef(summary(mle(mll)))[1])
mle_phi <- suppressWarnings(coef(summary(mle(mll)))[2])
intercept <- (log(mle_mu/(1-mle_mu))); intercept
mle_phi

# 7.5
plot(log(BF4$totexp), BF4$wfood, xlab = "log(totexp)", ylab = "wfood")

# 7.6
library(betareg)
model <- betareg(wfood ~ poly(log(totexp), 2), data = BF4)
summary(model)
sorted <- order(log(BF4$totexp))
sorted_totexp <- log(BF4$totexp)[sorted]
sorted_mu <- predict(model)[sorted]
lines(sorted_totexp, sorted_mu, col = 'red', lwd = 5)
lines(sorted_totexp, predict(model, type="response")[sorted], col="green", lty="dashed", lwd = 3)
lines(sorted_totexp, predict(model, type="quantile", at=0.95)[sorted], col="blue",)
lines(sorted_totexp, predict(model, type="quantile", at=0.05)[sorted], col="blue")

# 7.7
r <- residuals(model, type="pearson")
logtot <- log(BF4$totexp)
plot(logtot, r^2)
lines(lowess(logtot, r^2, iter=0), col="red")

# 7.8
betaregmodel <- betareg(BF4$wfood~poly(log(totexp), 2)|poly(log(totexp), 2), data = BF4)
summary(betaregmodel)
par(mfrow = c(1,2))
plot(log(BF4$totexp), BF4$wfood, xlab = "log(totexp)", ylab = "wfood")
sorted <- order(log(BF4$totexp))
sorted_totexp <- log(BF4$totexp)[sorted]
sorted_predict <- predict(betaregmodel)[sorted]
lines(sorted_totexp, sorted_predict, col = 'red', lwd = 5)
lines(sorted_totexp, predict(betaregmodel, type="response")[sorted], col="green", lty="dashed", lwd = 3)
lines(sorted_totexp, predict(betaregmodel, type="quantile", at=0.95)[sorted], col="blue",)
lines(sorted_totexp, predict(betaregmodel, type="quantile", at=0.05)[sorted], col="blue")
r <- residuals(betaregmodel, type="pearson")
logtot <- log(BF4$totexp)
plot(logtot, r^2)
lines(lowess(logtot, r^2, iter=0), col="red")
par(mfrow = c(1,1))
