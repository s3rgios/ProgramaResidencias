﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedToner
{
    internal class Validacion
    {
		public static void SoloLetras(KeyPressEventArgs V)
		{
			if (Char.IsLetter(V.KeyChar))
			{
				V.Handled = false;	
			}
			else if (Char.IsSeparator(V.KeyChar))
			{
				V.Handled = false;
			}
			else if (Char.IsControl(V.KeyChar))
			{
				V.Handled = false;
			}
			else
			{
				V.Handled = true;
			}
		}


		public static void SoloNumeros(KeyPressEventArgs V)
		{
			if (Char.IsNumber(V.KeyChar))
			{
				V.Handled = false;
			}
			else if (Char.IsSeparator(V.KeyChar))
			{
				V.Handled = false;
			}
			else if (Char.IsControl(V.KeyChar))
			{
				V.Handled = false;
			}
			else
			{
				V.Handled = true;
			}
		}

		public static void SoloLetrasYNumeros(KeyPressEventArgs V)
		{
			if (Char.IsLetter(V.KeyChar))
			{
				V.Handled = false;
			}
			else if (Char.IsNumber(V.KeyChar))
			{
				V.Handled = false;
			}
			else if (Char.IsSeparator(V.KeyChar))
			{
				V.Handled = false;
			}
			else if (Char.IsControl(V.KeyChar))
			{
				V.Handled = false;
			}
			else
			{
				V.Handled = true;
			}
		}
	}
}
