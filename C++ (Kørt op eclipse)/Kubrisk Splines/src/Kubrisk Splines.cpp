#include <iostream>
#include <vector>
#include <cmath>
#include <iomanip>
#include <fstream>
#include <functional>
#include <utility>
#include <random>

using namespace std;
using Vektor = vector<double>;
using Matrix = vector<Vektor>;
using Funk = function<double(double)>;
using Funkivv = function<double(int, Vektor, Vektor)>;
using Funkivvv = function<double(int, Vektor, Vektor, Vektor)>;

double funktion(double x);
pair<Matrix,Vektor> splines(Vektor x, Vektor y,size_t n);
void udskriv_vektor(const Vektor& v);
Matrix dan_matrix(size_t m, size_t n);
void udskriv_matrix(const Matrix& A);
Matrix dan_totalmatrix(const Matrix& A,const Vektor& b);
Vektor bsub(const Matrix& T);
bool gauss_elim(Matrix& T, double eps);
void ombyt(Matrix& T, size_t i1, size_t i2);
pair<size_t, size_t> size(const Matrix& A);
pair<Vektor,Vektor> x_y(double x0, double xn, size_t n, Funk f);
Matrix poly(Vektor x, Vektor y, Vektor v, size_t n, Funkivv fa1, Funkivv fa2, Funkivvv fa3, Funkivvv fa4);
void gem_matrix(string fn, const Matrix& A);
double Fa1(int i, const Vektor& v, const Vektor& x);
double Fa2(int i, const Vektor& v, const Vektor& x);
double Fa3(int i, const Vektor& v, const Vektor& x, const Vektor& y);
double Fa4(int i, const Vektor& v, const Vektor& x, const Vektor& y);
//test
Vektor hent_vektor(string fn);

int main() {
	size_t n=99;
	// auto [x,y]=x_y(0,10,n,funktion);
	//test
	Vektor x=hent_vektor("x.txt");
	Vektor y=hent_vektor("y.txt");
	auto [A,r]= splines(x,y,n);
	cout<<"x= \n";
	udskriv_vektor(x);
	cout<<"r= \n";
	udskriv_vektor(r);
	cout<<"A= \n";
	udskriv_matrix(A);
	Matrix T=dan_totalmatrix(A,r);
	if (!gauss_elim(T, 1e-12)){
		cout <<"fejl, matricen er singulær";
		return {};
	}
	udskriv_matrix(T);

	Vektor v=bsub(T);
	v.insert(v.begin(), 0);
	v.insert(v.end(), 0);
	cout<<"v= \n";
	udskriv_vektor(v);
	Matrix pi=poly(x,y,v,n,Fa1,Fa2,Fa3,Fa4);
	cout<<"pi= \n";
	udskriv_matrix(pi);
	gem_matrix("pi.txt",pi);
	return 0;
}

pair<Matrix,Vektor> splines(Vektor x, Vektor y, size_t n){
	Matrix A=dan_matrix(n-1,n-1);
	Vektor r(n-1);
	for (int i = 0; i < n-1; i++) {
		r[i]=6*((y[i+2]-y[i+1])/(x[i+2]-x[i+1])-(y[i+1]-y[i])/(x[i+1]-x[i]));
		for (int k=i; k<i+2; k++){
			if(i==k)
				A[i][k]=2*(x[i+2]-x[i]);
			else {
				A[i][k]=x[i+2]-x[i+1];
				if(!(k==n-1))
					A[k][i]=A[i][k];
			}
		}
	}
	return {A,r};
}

double funktion(double x){
	return cos(x)+0.5*cos(2*x)+(1.0/3)*cos(3*x);
}

void udskriv_vektor(const Vektor& v) {
	cout << "(";
	if (!v.empty()) {
		cout << v[0];
		for(size_t k = 1; k < v.size(); k++) {
			cout << ", "<< v[k];
		}
	}
	cout << ")\n";
}

Matrix dan_matrix(size_t m, size_t n) {
	return Matrix(m, Vektor(n));
}

void udskriv_matrix(const Matrix& A) {
	cout <<endl;
	for (const auto& v: A) {
		for (const auto& e: v) {
			cout << setw(10) << e;
		}
		cout << endl;
	}
	cout <<endl;
}

bool gauss_elim(Matrix& T, double eps){
	size_t n = T.size();
	for (size_t j = 0; j < n-1; j++) {
		int p=j;
		for (size_t i=j+1;i<n;i++){
			if (abs(T[i][j])>abs(T[p][j]))
				p=i;
		}
		if (p!=j)
			ombyt(T,p,j);
		if(abs(T[j][j])<eps){
			return false;
		}
		for (size_t i = j+1; i < n; i++) {
			double a=-T[i][j]/T[j][j];
			T[i][j]=0;
			for (size_t k = j+1; k < n+1; k++) {
				T[i][k]+=a*T[j][k];
			}
		}
	}
	if (abs(T[n-1][n-1])<eps){
		return false;
	}
	else
		return true;
}

Vektor bsub(const Matrix& T){
	int m= T.size();
	Vektor x(m);
	x[m-1]=T[m-1][m]/T[m-1][m-1];
	for (int i=m-2;i>-1;i--){
		double sum=0;
		for (size_t j=i+1;j<m;j++){
			sum+=T[i][j]*x[j];
		}
		x[i]=(T[i][m]-sum)/T[i][i];
	}
	return x;
}

Matrix dan_totalmatrix(const Matrix& A,const Vektor& b){
	const auto [m,n] = size(A);
	Matrix T = dan_matrix(m,n+1);
	for(size_t i=0;i<m;i++){
		for(size_t j=0;j<n+1;j++) {
			if(j<n)
				T[i][j]=A[i][j];
			else
				T[i][j]=b[i];
		}
	}
	return T;
}

void ombyt(Matrix& T, size_t i1, size_t i2) {
	swap(T[i1], T[i2]);
}

pair<size_t, size_t> size(const Matrix& A) {
	size_t n=0,m=A.size();
	if (m>0)
		n=A[0].size();
	return {m,n};
}

pair<Vektor,Vektor> x_y(double x0, double xn, size_t n, Funk f){
	Vektor x(n+1), y(n+1);
	for(size_t i=0;i<n+1;i++){
		x[i]=x0+(xn-x0)*i/(n);
		y[i]=f(x[i]);
	}
	return {x,y};
}

Matrix poly(Vektor x, Vektor y, Vektor v, size_t n, Funkivv fa1, Funkivv fa2, Funkivvv fa3, Funkivvv fa4){
	Matrix pi=dan_matrix(n,4);
	for(size_t i=1;i<n+1;i++){
		pi[i-1][0]=fa1(i,v,x)*pow(x[i],3)-fa2(i,v,x)*pow(x[i-1],3)+fa3(i,v,x,y)*x[i]-fa4(i,v,x,y)*x[i-1];
		pi[i-1][1]=-3*fa1(i,v,x)*pow(x[i],2)+3*fa2(i,v,x)*pow(x[i-1],2)-fa3(i,v,x,y)+fa4(i,v,x,y);
		pi[i-1][2]=3*fa1(i,v,x)*x[i]-3*fa2(i,v,x)*x[i-1];
		pi[i-1][3]=fa2(i,v,x)-fa1(i,v,x);
	}
	return pi;
}

void gem_matrix(string fn, const Matrix& A) {
	ofstream fil(fn);
	if(!fil) {
		cout << "Fejl i �bning af filen " << fn << ".\n";
		return;
	}
	fil << setprecision(16);
	for (size_t i = 0; i < A.size(); i++) {
		for (size_t j = 0; j < A[0].size(); j++) {
			if (j > 0)
				fil << " ";
			fil << A[i][j];
		}
		fil << endl;
	}
}

double Fa1(int i, const Vektor& v, const Vektor& x){
	return v[i-1]/(6*(x[i]-x[i-1]));
}

double Fa2(int i, const Vektor& v, const Vektor& x){
	return v[i]/(6*(x[i]-x[i-1]));
}

double Fa3(int i, const Vektor& v, const Vektor& x, const Vektor& y){
	return y[i-1]/(x[i]-x[i-1])-(v[i-1]*(x[i]-x[i-1]))/6;
}

double Fa4(int i, const Vektor& v, const Vektor& x, const Vektor& y){
	return y[i]/(x[i]-x[i-1])-(v[i]*(x[i]-x[i-1]))/6;
}

//test
Vektor hent_vektor(string fn) {
	Vektor v;
	ifstream fil(fn);
	if (!fil.is_open()) {
		cout << "Kunne ikke  bne filen " << fn << ".\n";
		return v;
	}
	for (double e; fil >> e;) {
		v.push_back(e);
	}
	return v;
}
