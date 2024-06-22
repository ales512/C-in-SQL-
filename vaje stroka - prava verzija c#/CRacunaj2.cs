using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaje_stroka___prava_verzija_c_
{
    /*Naloga 2
 
	Razširi 1. primer tako, da omogoča prenos rezultata v novo Formo (Forma2), kjer lahko nad tem številom
	prav tako izvajamo osnovne računske operacije (podoben vmesnik, kot ima Naloga 1). Formo lahko zapustimo z 
	gumboma "Potrdi" in "Prekliči".
	V kolikor uporabnik pritisne "Potrdi" se naj rezultat Forme2 prenese v 1. vnosno polje na osnovni formi.*/

     class CRacunaj2
    {
        public int a
        {
            get;
            set;
        }

        public int b
        {
            get; set;
        }

        public CRacunaj2(int a, int b)
        {
            this.a = a;
            this.b = b;
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
