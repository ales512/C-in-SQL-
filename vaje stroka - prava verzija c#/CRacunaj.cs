using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaje_stroka___prava_verzija_c_
{

    /*Naloga 1

	Napiši namizno aplikacijo (Winforms/wpf..), ki omogoča osnovne računske operacije (+,*,/,-) nad dvema številoma,
	ki ju uporabnik vnese (cela števila - rezultat pa naj bo decimalno število zaokr. na 4. decimalke).
	Vsako število se naj vnese v svoje vnosno polje. Aplikacija mora biti odporna na napake pri vnosu
	uporabnika. 
	Vso računanje naj se izvaja v razredu CRacunaj, ki mora omogočati vnos 2 spremenljiv v konstruktorju
	in s set metodo.

	ex.:
	CRacunaj m_racunaj = new CRacunaj(53,2);
	decimal rezultat1 = m_racunaj.Sestej();
	CRacunaj m_racunaj2 = new CRacunaj();
	m_racunaj2.a = 3;
	m_racunaj2.b = 4;
	decimal rezultat2 = m_racunaj2.Sestej();
*/
    class CRacunaj
    {
        private double num1;
        private int num2;
        private decimal num11;
        private decimal num21;

        public int a
        {
            get;
            set;
        }

        public int b
        {
            get; set;
        }

        public CRacunaj(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public CRacunaj(double num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        public CRacunaj(decimal num11, decimal num21)
        {
            this.num11 = num11;
            this.num21 = num21;
        }

        public decimal Add()
        {
            return Math.Round((decimal)a + b, 4);
        }

        public decimal Subtract()
        {
            return Math.Round((decimal)a - b, 4);
        }

        public decimal Multiply()
        {
            return Math.Round((decimal)a * b, 4);
        }
        public decimal Divide()
        {
            if (b == 0)
                throw new DivideByZeroException("Division by zero is not allowed.");
            return Math.Round((decimal)a / b, 4);
        }

    }
}
