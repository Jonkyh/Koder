#include <iostream> //cout + cin
#include <vector> //vector
#include <fstream> //fileoutput
#include <iomanip> //setw
#include <cmath> //pow

using namespace std;

using Vektor = vector<double>;
using Matrix = vector<Vektor>; // vector<vector<double>>

//Funktionerdeklarationer

//Erklærer de forskellige funktioner til hhv. vektorer og matricer.
void velkomsttekst();
Vektor hent_vektor(string fn);
Matrix dan_matrix(size_t m, size_t n);
void udskriv_vektor(const Vektor& v);
void udskriv_matrix(const Matrix& A);
pair<size_t, size_t> size(const Matrix& A);
pair<double, double> minmax(const Vektor& x);

//Erklærer funktioner til De Boors algoritme
Vektor eval_spline(const Vektor& t, int k, int v, double x);
int vknude(const Vektor& t, double x);
Vektor dan_knudepunkter(double tmin, double tmax, int l, int k);
Matrix spline_totalmatrix(const Vektor& t, int k, const Vektor& x, const Vektor& y);

//Erklærer funktioner til Householders algoritme
Vektor house(const Matrix& T, int j);
void anvend_house(Matrix& T, const Vektor& v, int j);
void houseQR(Matrix& T);
Vektor bsub(const Matrix& T);


int main() {
	velkomsttekst();
	Vektor xv = hent_vektor("x.txt");
	Vektor yv = hent_vektor("y.txt");

	auto[xmin,xmax] = minmax(xv);
	cout << "xmin: " << xmin << endl;
	cout << "xmax: " << xmax << endl;

	int k, l;
	cout << "Indtast k: ", cin >> k;
	cout << "Indtast l: ", cin >> l;
	Vektor t = dan_knudepunkter(xmin, xmax , l, k);
	cout << "Knudepunkter t: " << endl;
	udskriv_vektor(t);
	cout << endl;

	cout << "Koefficient Matrix: " << endl;
	Matrix TM = spline_totalmatrix(t, k, xv, yv);
	udskriv_matrix(TM);

	houseQR(TM);
	Vektor c = bsub(TM);
	cout << "House: " << endl;
	udskriv_matrix(TM);
	cout << "\n" << endl;

	cout << "Vektor c: " << endl;
	udskriv_vektor(c);

	return 0;
}

void velkomsttekst(){
	cout << "Velkommen til mit projekt\n" << endl;

	cout << "Formålet for programmet er at minimere normen af vektoren Ac-y.\n"
			"Et sådant minimeringsproblem kaldes for mindste kvadraters metode" << endl;

	cout << "Opgaven beskæftiger sig med De Boors algoritme til at danne en totalmatrix\n"
			"og Householders algoritme til at løse problemet.\n" << endl;
}

Vektor hent_vektor(string fn) {
	Vektor v;
	ifstream fil(fn);

	if (!fil.is_open()) {
		cout << "Kunne ikke åbne filen " << fn << ".\n";
		return v;
	}

	for (double e; fil >> e;) {
		v.push_back(e);
	}

	return v;
}

Matrix dan_matrix(size_t m, size_t n) {
	return Matrix(m, Vektor(n));
}

void udskriv_vektor(const Vektor& v) {
	cout << "{";
	if (!v.empty()) {
		cout << v[0];
		for(size_t k = 1; k < v.size(); k++) {
			cout << ", " << v[k];
		}
	}
	cout << "}\n";
}

void udskriv_matrix(const Matrix& A) {
	for (const auto& v: A) {
		for (const auto& e: v) {
			cout << setw(15) << e;
		}
		cout << endl;
	}
}

//Returnerer Matrix A's størrelsen (mxn)
pair<size_t, size_t> size(const Matrix& A) {
	size_t n=0,m=A.size();
	if (m>0)
		n=A[0].size();
	return {m,n};
}

//Returnerer den mindste og største værdi fra vektor x.
pair<double, double> minmax(const Vektor& x){
	double xmin = x[0];
	double xmax = x[0];

	for (size_t i = 0; i < x.size(); i++){
		if (x[i] < xmin){
			xmin = x[i];
		}
		else if (x[i] > xmax){
			xmax = x[i];
		}
	}
	return {xmin,xmax};
}


//Evaluer alle ikke-nul B-splines af orden k (grad k-1) med knudepunkter i t i x.
Vektor eval_spline(const Vektor& t, int k, int v, double x){
	Vektor b(k), dL(k-1), dR(k-1);
	double term, saved;

	for (int s = 0; s <= k-2; s++){
		dL[s] = x - t[v-s];
		dR[s] = t[v+1+s]-x;
	}
	b[0]=1;

	for (int j = 1; j <= k-1; j++){
		saved = 0;

		for (int r = 0; r <= j-1; r++){
			term = b[r]/(dL[j-1-r]+dR[r]);
			b[r] = saved + (dR[r]*term);
			saved = dL[j-1-r]*term;
		}
		b[j]=saved;
	}
	return b;
}

//Danner en vektor med knudepunkter
Vektor dan_knudepunkter(double tmin, double tmax, int l, int k){
	//Definerer størrelsen til vektor t:
	int n = k*2+l-1;
	Vektor t(n);

	//De første k skal være lig med det mindste element i x (tmin)
	//De sidste k skal være lig med det maksimale element i x (tmax)
	for (int i = 0; i < k; i++){
		t[i] = tmin;
		t[n-i-1] = tmax;
	}

	//Danner ækviditant.
	double dt =(tmax - tmin)/l;
	double x = tmin;

	//Danner de midterste punkter, der er ækvidistant fordelt:
	for (int j = k-1; j < n-k; j++){
		t[j] = x;
		x += dt;
	}

	//Vektor t returneres
	return t;
}

int vknude(const Vektor& t, double x){
	int n = t.size();

	//Sikre os, at x ikke er "udenfor" af de område, vi ønsker at beregne.
	if (x < t[0]){
		return 0;
	}

	//Der findes den v, der er større end x
	//og dermed returnes v-1, altså række før.
	for (int v = 0; v < n; v++){
		if (t[v] > x){
			return v-1;
		}
	}
	//Returner det sidste indeks i vektor t.
	return n-1;
}

//Koefficientmatricen dannes ved hjælp af De Boors algoritme
Matrix spline_totalmatrix(const Vektor& t, int k, const Vektor& x, const Vektor& y){
	size_t m = x.size();
	int n = t.size()-k; //da vi ikke kender l (t.size() - k)
	Matrix TM = dan_matrix(m,n+1); //da vi også skal have konstantsøjlen.

	for (size_t i = 0; i < m; i++){
		int v = vknude(t, x[i]);
		if (v >= n){
			v = n-1;
		}
		Vektor b = eval_spline(t, k, v, x[i]);
		for (int j = 0; j < k; j++){ //Der tilføjes data på hver søjler i i-række indtil konstantsøjlen.
			TM[i][j+v-(k-1)] = b[j];
		}
		TM[i][n] = y[i]; //Danner konstantsøjlen
	}

	return TM;
}

//Dan v for en Householder-transformation der kan skabe nuller i søjle j af T
Vektor house(const Matrix& T, int j){
	double m = T.size(); //m = antal rækker
	double sigma = 0;
	//Definerer vektor v med størrelsen (m-j)
	Vektor v(m-j);

	for (int i = 1; i < m-j; i++){
		sigma = sigma + pow(T[j+i][j],2);
		v[i] = T[j+i][j];
	}

	double my = sqrt(pow(T[j][j],2) + sigma);

	//v[] startes i 0 grundet nulindekseret.
	if(T[j][j] <= 0){
		v[0] = T[j][j]-my;
	}
	else{
		v[0] = (-sigma) / (T[j][j]+my);
	}

	return v;
}

// Housholder-transformation anvendes på Ts undermatrix startende i række og søjle j.
void anvend_house(Matrix& T, const Vektor& v, int j){
	auto[m,n] = size(T);
	n--; //konstantsøjle tages ikke med:

	for (size_t k = 0; k <= n-j; k++){
		double pi = 0;
		double gamma = 0;

		for (size_t i = 0; i < m-j; i++){
			pi = pi + (v[i] * T[j+i][j+k]);
			gamma = gamma + (v[i]*v[i]);
		}

		double beta = 2.0/gamma;

		for (size_t i = 0; i < m-j; i++){
			T[j+i][j+k] -= (beta*pi*v[i]);
		}
	}
}

//Householder QR for totalmatrix. R bliver lagt i øvre trekant af T.
void houseQR(Matrix& T){
	auto[m,n] = size(T);
	n--;

	for (size_t j = 0; j < n; j++){
		Vektor v = house(T,j);
		anvend_house(T,v,j);
	}
}

 //Løser Rc = v med baglæns substitution under antagelse af at R er en øvre trekantsmatrix.
Vektor bsub(const Matrix& T){
	int n = T[0].size();
	int m = n-1;

	Vektor c(m);

	c[m-1] = T[m-1][m]/T[m-1][m-1];
	for (int i = m-2; i >= 0; i--){
		double sum = 0;
		for (int j = i+1; j < m; j++){
			sum += T[i][j]*c[j];
		}
		c[i] = (T[i][m]-sum)/T[i][i];
	}
	return c;
}
