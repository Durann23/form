using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ClassLibrary1;

namespace sensores
{
	public partial class Form1 : Form
	{
		System.IO.Ports.SerialPort Port;
		bool IsClosed = false;
		Class1 sensores = new Class1();
		public Form1()
		{
			InitializeComponent();
			Port = new System.IO.Ports.SerialPort();
			Port.PortName = "COM4";
			Port.BaudRate = 9600;
			Port.ReadTimeout = 500;

			Port.Open();
			Thread asd = new Thread(LeerDatos);
			asd.Start();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		private void LeerDatos()
		{
			while (!IsClosed)
			{
				try
				{
					string data = Port.ReadLine();
					char[] arra=data.ToCharArray();
					string env = Convert.ToString(arra[0] + arra[1]);
					string nume = Convert.ToString(arra[2] + arra[3]);
					string unidad = Convert.ToString(arra[2] + arra[3]);
					sensores.checar(env);
					label2.Text=sensores.Nombre;
					label3.Text=sensores.Unidad;
					//label5.Text=
					//label7.Text=sensores.Nombre+nume+":"+

					
				}
				catch (TimeoutException)
				{
				}
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Port.IsOpen)
			{
				Port.Close();
			}
		}
	}
}
