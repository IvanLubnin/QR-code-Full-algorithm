using System; 
using System.Drawing;
    					
    
	public class Program
    {


    	const string white = "⬜"; // 0,3
	    const string black = "⬛"; // 1,2
		const string red = "🟥";   // 4
		
		static int[] gm = new int[7] {87, 229, 146, 149, 238, 102, 21};//генерирующий многочлен
		static int[] tab7 = new int[256] {1, 2, 4, 8, 16, 32, 64, 128, 29, 58, 116, 232, 205, 135, 19, 38, 76, 152, 45, 90, 180, 117, 234, 
									   201, 143, 3, 6, 12, 24, 48, 96, 192, 157, 39, 78, 156, 37, 74, 148, 53, 106, 212, 181, 119, 238, 
									   193, 159, 35, 70, 140, 5, 10, 20, 40, 80, 160, 93, 186, 105, 210, 185, 111, 222, 161, 95, 190, 97, 
									   194, 153, 47, 94, 188, 101, 202, 137, 15, 30, 60, 120, 240, 253, 231, 211, 187, 107, 214, 177, 127,
									   254, 225, 223, 163, 91, 182, 113, 226, 217, 175, 67, 134, 17, 34, 68, 136, 13, 26, 52, 104, 208,
									   189, 103, 206, 129, 31, 62, 124, 248, 237, 199, 147, 59, 118, 236, 197, 151, 51, 102, 204, 133, 
									   23, 46, 92, 184, 109, 218, 169, 79, 158, 33, 66, 132, 21, 42, 84, 168, 77, 154, 41, 82, 164, 85, 
									   170, 73, 146, 57, 114, 228, 213, 183, 115, 230, 209, 191, 99, 198, 145, 63, 126, 252, 229, 215, 
									   179, 123, 246, 241, 255, 227, 219, 171, 75, 150, 49, 98, 196, 149, 55, 110, 220, 165, 87, 174, 65, 
									   130, 25, 50, 100, 200, 141, 7, 14, 28, 56, 112, 224, 221, 167, 83, 166, 81, 162, 89, 178, 121, 242, 
									   249, 239, 195, 155, 43, 86, 172, 69, 138, 9, 18, 36, 72, 144, 61, 122, 244, 245, 247, 243, 251, 235, 
									   203, 139, 11, 22, 44, 88, 176, 125, 250, 233, 207, 131, 27, 54, 108, 216, 173, 71, 142, 1};
		
		static int[] tab8 = new int[256] {0, 0, 1, 25, 2, 50, 26, 198, 3, 223, 51, 238, 27, 104, 199, 75, 4, 100, 224, 14, 52, 141, 239, 
									   129, 28, 193, 105, 248, 200, 8, 76, 113, 5, 138, 101, 47, 225, 36, 15, 33, 53, 147, 142, 218, 240, 
									   18, 130, 69, 29, 181, 194, 125, 106, 39, 249, 185, 201, 154, 9, 120, 77, 228, 114, 166, 6, 191, 139, 
									   98, 102, 221, 48, 253, 226, 152, 37, 179, 16, 145, 34, 136, 54, 208, 148, 206, 143, 150, 219, 189, 
									   241, 210, 19, 92, 131, 56, 70, 64, 30, 66, 182, 163, 195, 72, 126, 110, 107, 58, 40, 84, 250, 133, 
									   186, 61, 202, 94, 155, 159, 10, 21, 121, 43, 78, 212, 229, 172, 115, 243, 167, 87, 7, 112, 192, 247, 
									   140, 128, 99, 13, 103, 74, 222, 237, 49, 197, 254, 24, 227, 165, 153, 119, 38, 184, 180, 124, 17, 68, 
									   146, 217, 35, 32, 137, 46, 55, 63, 209, 91, 149, 188, 207, 205, 144, 135, 151, 178, 220, 252, 190, 97, 
									   242, 86, 211, 171, 20, 42, 93, 158, 132, 60, 57, 83, 71, 109, 65, 162, 31, 45, 67, 216, 183, 123, 164, 
									   118, 196, 23, 73, 236, 127, 12, 111, 246, 108, 161, 59, 82, 41, 157, 85, 170, 251, 96, 134, 177, 187, 204, 
									   62, 90, 203, 89, 95, 176, 156, 169, 160, 81, 11, 245, 22, 235, 122, 117, 44, 215, 79, 174, 213, 233, 230, 231, 
									   173, 232, 116, 214, 244, 234, 168, 80, 88, 175, };
		
	    public static void FillMatrixFromString(string n) 
    	{
    		//первая фаза заполнения из строки 
    		int c = 0;
    		int i = 20;
    		int j = 20;
    		int[,] m = new int[21,21];
    		FillingConstantvalues(m);
    		for(int x = 0;x<7;x++)
    		{
    			if (x%2 == 0)
    			{
    				while (i >= 0)
    				{
    					if ((m[i,j] != 2) & (m[i,j] != 3))
    					{
    						if(m[i,j] == 4)
    						{	
    							switch (n[c])
    							{
    								case '0': m[i,j] = 1; break;
    								case '1': m[i,j] = 0; break;
    							}
    							c++;
    						}	
    						else
    						{
    							switch (n[c])
    							{
    								case '0': m[i,j] = 0; break;
    								case '1': m[i,j] = 1; break;
    							}
    							c++;
    						}
    					}	
    					j--;
    					if ((m[i,j] != 2) & (m[i,j] != 3))
    					{
    						if(m[i,j] == 4)
    						{
    							switch (n[c])
    							{
    								case '0': m[i,j] = 1; break;
    								case '1': m[i,j] = 0; break;
    							}
    							c++;
    						}	
    						else
    						{
    							switch (n[c])
    							{
    								case '0': m[i,j] = 0; break;
    								case '1': m[i,j] = 1; break;
    							}
    							c++;
    						}
    					}	
    					j++;
    					i--;
    				}
    			i++;
    			j = j-2;
    			}
    			else
    			{
    				while (i <= 20)
    				{
    					if ((m[i,j] != 2) & (m[i,j] != 3))
    					{
    						if(m[i,j] == 4)
    						{	
    							switch (n[c])
    							{
    								case '0': m[i,j] = 1; break;
    								case '1': m[i,j] = 0; break;
    							}
    							c++;
    						}	
    						else
    						{
    							switch (n[c])
    							{
    								case '0': m[i,j] = 0; break;
    								case '1': m[i,j] = 1; break;
    							}
    							c++;
    						}
    					}	
    					j--;
    					if ((m[i,j] != 2) & (m[i,j] != 3))
    					{
    						if(m[i,j] == 4)
    						{
    							switch (n[c])
    							{
    								case '0': m[i,j] = 1; break;
    								case '1': m[i,j] = 0; break;
    							}
    							c++;
    						}	
    						else
    						{
    							switch (n[c])
    							{
    								case '0': m[i,j] = 0; break;
    								case '1': m[i,j] = 1; break;
    							}
    							c++;
    						}
    					}	
    					j++;
    					i++;
    				}
    			i--;
    			j = j-2;
    			}
    		}
    		
    		//вторая фаза заполнение из строки
    		i = 9;
    		j = 5;
    		for(int x = 1;x<4;x++)
    		{	
    			if (x%2!=0)
    			{	
    			   while (i <= 12)
    				{
    					if(m[i,j] == 4)
    					{	
    						switch (n[c])
    						{
    							case '0': m[i,j] = 1; break;
    							case '1': m[i,j] = 0; break;
    						}
    						c++;
    					}	
    					else
    					{
    						switch (n[c])
    						{
    							case '0': m[i,j] = 0; break;
    							case '1': m[i,j] = 1; break;
    						}
    						c++;
    					}
    					j--;
    					if(m[i,j] == 4)
    					{	
    						switch (n[c])
    						{
    							case '0': m[i,j] = 1; break;
    							case '1': m[i,j] = 0; break;
    						}
    						c++;
    					}	
    					else
    					{
    					switch (n[c])
    						{
    							case '0': m[i,j] = 0; break;
    							case '1': m[i,j] = 1; break;
    						}
    						c++;
    					}
    					j++;
    					i++;	
    				}
    				i--;
    				j=j-2;
    			}
    			else
    			{
    				while (i >= 9)
    				{
    					if(m[i,j] == 4)
    					{	
    						switch (n[c])
    						{
    							case '0': m[i,j] = 1; break;
    							case '1': m[i,j] = 0; break;
    						}
    						c++;
    					}	
    					else
    					{
    						switch (n[c])
    						{
    							case '0': m[i,j] = 0; break;
    							case '1': m[i,j] = 1; break;
    						}
    						c++;
    					}
    					j--;
    					if(m[i,j] == 4)
    					{	
    						switch (n[c])
    						{
    							case '0': m[i,j] = 1; break;
    							case '1': m[i,j] = 0; break;
    						}
    						c++;
    					}	
    					else
    					{
    						switch (n[c])
    						{
    							case '0': m[i,j] = 0; break;
    							case '1': m[i,j] = 1; break;
    						}
    						c++;
    					}
    					j++;
    					i--;	
    				}
    				i++;
    				j=j-2;
    			}	
    		}
    		
			//LogMatrix(m);
            
            //создаем и заполяем файл для сохранения QR-кода

            Bitmap bitmap = new Bitmap(800, 800, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            SolidBrush whitebrush = new SolidBrush(Color.White);
            SolidBrush blackbrush = new SolidBrush(Color.Black);
            
            int size = 30;
            int x1 = 85;
            int y1 = 85;
            
            int h = 0;
            int k = 0;
            graphics.FillRectangle(whitebrush, 0, 0, 800, 800);
            for(k = 0;k<21;k++)   
            {
                x1 = 85;
                y1 = 85+size*k;
                for(h = 0;h<21;h++)
                {
                    switch (m[k,h])
                    {
                        case 0: graphics.FillRectangle(whitebrush, x1, y1, size, size); break;
                        case 3: graphics.FillRectangle(whitebrush, x1, y1, size, size); break;
                        case 1: graphics.FillRectangle(blackbrush, x1, y1, size, size); break;
                        case 2: graphics.FillRectangle(blackbrush, x1, y1, size, size); break;
                    }
                    x1 = x1+size;
                    
                    
                }
                x1 = 85;
                y1 = 85+size*k;
            }   
            bitmap.Save(@"QR-code.png");
    	}
		public static void FillingConstantvalues(int[,] m) //заполнение QR-кода неизменными значениями
		{
			//заполянем неизменные черные
			for(int i = 0;i<7;i++)
			{
				m[0,i] = 2;     // m[строка,столбец]
				m[6,i] = 2;     // 1 - черный, 2 - неизменный черный, 3 - неизменный белый (оранжевый на стадии разработки), 4 - маска QR-кода (пусть будет красным)
				m[6,i] = 2;
				m[14,i] = 2;
				m[20,i] = 2;
				m[i,0] = 2;
				m[i,6] = 2;
				m[i,14] = 2;
				m[i,20] = 2;
				m[0,i+14] = 2;
				m[6,i+14] = 2;
				m[14+i,0] = 2;
				m[14+i,6] = 2;
			}
			for (int i = 0;i<3;i++)
			{
				m[2,2+i] = 2;
				m[3,2+i] = 2;
				m[4,2+i] = 2;
				m[8,6+i] = 2;
			}
			for (int i = 0;i<3;i++)
			{
				m[2,16+i] = 2;
				m[3,16+i] = 2;
				m[4,16+i] = 2;
				
			}
			for (int i = 0;i<3;i++)
			{
				m[16,2+i] = 2;
				m[17,2+i] = 2;
				m[18,2+i] = 2;
			}
	        for(int i = 0;i<5;i++)
			{
				m[8,i] = 2;
				m[16+i,8] = 2;
			}
			for(int i = 0;i<5;i++)
			{
				m[8,i] = 2;
				m[16+i,8] = 2;
			}
			for(int i = 0;i<2;i++)
			{
				m[i+5,8] = 2;
				m[i+13,8] = 2;
			}
			m[1,8] = 2;
			m[3,8] = 2;
			m[10,6] = 2;
			m[12,6] = 2;
			m[6,10] = 2;
			m[6,12] = 2;
			m[8,13] = 2;
			m[8,15] = 2;
			m[8,17] = 2;
			m[8,19] = 2;
			
			//заполянем неизменные белые 
			for(int i = 0;i<8;i++)
			{
				m[i,7] = 3;
				m[i,13] = 3;
				m[13+i,7] =3;
				m[7,i] = 3;
				m[7,13+i] = 3;
				m[13,i] = 3;
			}	
			for(int i = 0;i<5;i++)
			{
				m[1,i+1] = 3;
				m[5,i+1] = 3;
				m[i+1,1] = 3;
				m[i+1,5] = 3;
				m[1,i+15] = 3;
				m[5,i+15] = 3;	
				m[i+1,15] = 3;
				m[i+1,19] = 3;
				m[15,i+1] = 3;
				m[19,i+1] = 3;
				m[i+15,1] = 3;
				m[i+15,5] = 3;
			}
			m[0,8]=3;
			m[2,8]=3;
			m[4,8]=3;
			m[7,8]=3;
			m[15,8]=3;
			m[8,5]=3;
			m[9,6]=3;
			m[11,6]=3;
			m[8,14]=3;
			m[8,16]=3;
			m[8,18]=3;
			m[8,20]=3;
			m[6,9]=3;
			m[6,11]=3;
			
			//заполянем "красные клетки" для маски коррекции
			for (int i = 0;i<4;i++)
			{
				m[i+9,0] = 4;
				m[i+9,3] = 4;
			}	
			for (int i = 0;i<6;i++)
			{
				m[i,9] = 4;
				m[i,12] = 4;
			}	
			for (int i = 0;i<14;i++)
			{
				m[i+7,9] = 4;
				m[i+7,12] = 4;
			}	
			for (int i = 0;i<12;i++)
			{
				m[i+9,15] = 4;
				m[i+9,18] = 4;
			}	
		}
		
		
		public static void WriteColor(int c) 
		{
			if (c == 0)
			{
				Console.Write(white);
		    } 
			else 
			{
			    if ((c == 1) || (c == 2))
				{
					Console.Write(black);
				}	
				else 
				{
					if ((c == 0))
					{
						Console.Write(white);
					}
					else
					{
						if (c == 3)
						{
							Console.Write(white);
						}
						else
						{
							Console.Write(red);
						}	
					}	
				}	
		    }
	    }
		
		public static void LogMatrix(int[,] matrix) //функция вывода двумерного массива на экран
		{
			int n = 21;
			for(int j=0;j<n;j++) 
			{
				for(int i=0;i<n;i++) 
				{
					WriteColor(matrix[j,i]);
				}
				Console.WriteLine();
			}			
	    }
		
		
		public static int[] IntArrayToCorrection (int[] mass)
		{
			for (int c =0;c<19;c++)
			{
				int[] corr = new int[7]; 
				int a,b;
				int[] v = new int[7];
				a = mass[0];
				for(int i = 0;i<mass.Length-1;i++)//Первый элемент сохраняем в А и удаляем. Сдвигаем массив на 1, последний элемент записать 0
				{
					mass[i]=mass[i+1];
				}
				mass[mass.Length-1]=0;

				if (a!=0)
				{
					b = tab8[a]; //Находим соответствующее числу А число в таблице tab8, заносим его в переменную Б
					for(int i = 0;i<7;i++)
						{
							v[i] = gm[i]+b;
						}
					for(int i = 0;i<7;i++)//Если В больше 254, надо использовать её остаток при делении на 255
					{
						if (v[i] > 254)
						{
							v[i] = v[i]%255;
						}
					}
					for(int i = 0;i<7;i++)//Замена В из таблицы tab7
					{
						v[i] = tab7[v[i]];
					}
					for(int i = 0;i<7;i++) 
					{
						mass[i] = mass[i] ^ v[i];
					}
				}
			}	
			return	mass;
		}
		
		public static int[] BinaryStringToIntArray  (string s)// функция перевода двоичной строки в числовой одномерный массив
		{
    		string[] mass = new string[19];
			for(int i = 0;i<19;i++)
			{
				for(int j = 0;j<8;j++)
				{
					mass[i] = mass[i] + s[j+8*i];
				}
			}	
    		int[] mass2 = new int[19];
			for (int i =0;i<19;i++)
			{
				mass2[i] = Program.BinaryIntToInt(Convert.ToInt32(mass[i]));
			}
			return mass2;
		}	
		
		
		public static int BinaryIntToInt(int n) // функция перевода чисел из двоичной СС в десятичную
    	{
			int i = 0;
			double s=0;
			int j = Convert.ToString(n).Length;
			while (i<j)
			{
				s = s + n%10*Math.Pow(2,i);
				n = n/10;
				i = i+1;
			}
			return Convert.ToInt32(s);
    	}	
		
		public static string Eight(string s)// маленька вспомогательная функция, дополняющая дес. число чтобы получился байт
		{
			     while (s.Length!= 8) 
    			     {
    					string x ="0";
    					x = x + s;
    				    s = x;
    			     }
			    return(s);
		}
		
		public static int IntToBinaryInt(int c)// функция перевода чисел из десятичной СС в двоичную
		{
    		int a = 0;
    	    int b = 1;
    		int d;
    		while (c > 0)
    		{
    			d = c%2;
    		    c = c/2;
    			a = a + d * b; 
    			b = b * 10;
    		}
		    return a;	
		}
		
		public static string CharToBinaryString(char ch)//перевод символа, а точнее его номер, в байт 
    	{
            int c = (int)ch;
    		c = Program.IntToBinaryInt(c);
    		string s = Convert.ToString(c);
    		s = Program.Eight(s);
            return s;
        }
    	
    	
        
        public static string StringToBinaryString(string s)//перевод введеной строки в двоичную строку
    	{
    	   string z ="";
    	   for(int i = 0;i<s.Length; i++) 
    	   {
    	      z = z+Program.CharToBinaryString(s[i]);
    	   }
    	   return z;
    	}

		public static void Main()
    	{	
  		 	string s ="";
			int i;
			do
			{ 
				Console.WriteLine("Enter the text you want to code");
    			s = Console.ReadLine();
				int a = Program.IntToBinaryInt(s.Length);
				s = Program.StringToBinaryString(s);//делаем из строки бинарный код
				string x=Program.Eight(a.ToString());//добавляем служебные данные
				x = x + s;
    			s = x; 
    			x = "0100";
				x = x + s;
				s = x;
				Console.WriteLine();
				if (s.Length > 152) //проверяем кол-во занимаемой памяти
				{
					Console.WriteLine("Exceeded allowed amount of memory");
				}
			}	
			while(s.Length > 152);
			while(s.Length%8!=0)//делаем строку кратной 8
			{
				s = s+"0";
			}	
			int y = 19 - s.Length/8;
			
			for( i = 0;i < y;i++)
			{
				if(i % 2==0)
				{
					s = s + "11101100";
				}	
				if(i % 2!=0)
				{
					s = s + "00010001";
				}	
			}
			
			int[] mass = Program.BinaryStringToIntArray(s);
			
			int[] mass2 = (int[])mass.Clone();
			
			mass2 = Program.IntArrayToCorrection(mass2);//создаем массив и заполняем его байтами коррекции
			
			for(i = 0;i<7;i++)
			{
				s = s + Eight(Convert.ToString(IntToBinaryInt(mass2[i])));//получение итоговой строки
			}
			
			FillMatrixFromString(s);//итоговое создание QR-кода c последующим заполнением его из строки,
									//после чего создается файл с конечным qr-кодом
            
            Console.WriteLine("The task completed. Check the image in your folder");
		}
	}