namespace a
{
    class Program
    {
        public static List<libro> libros = new List<libro>();
        public static void Main(string[] args)
        {

            
            DateTime hoy = DateTime.Now;
            string ruta = "C:\\Users\\andre\\OneDrive\\Escritorio\\"+hoy.ToString("ddMMyyyy")+"hola";
            lectura(ruta);
            //lect(ruta);   
            Console.WriteLine("escribe nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("escribe fecha");
            DateTime dateTime  =Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("cantidad");
            int cantidad  = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("dni");
            string d = dni();
            libro libro = new libro(nombre,dateTime,cantidad,d);
            libros.Add(libro);
            StreamWriter streamWriter = new StreamWriter(ruta);

            foreach (libro libro1 in libros)
            {
                streamWriter.WriteLine(libro1.Nombre+";"+libro1.Hoy.ToString("dd-MM-yyyy")+";" +libro1.Manana.ToString("dd-MM-yyyy") +";"+libro1.Cantidad + ";" + libro1.Dni);
                Console.WriteLine(libro1.ToString());
                
            }
            streamWriter.Close();

        }
        public static string dni()
        {
            char[] letras = new char[] { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };

            int dniNum=1;
            char letra='a';
            bool comprobante = false;
            while (!comprobante) 
            {
                Console.WriteLine("Dame el dni(Numero)");
                dniNum = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Dame el dni(Letra en mayuscula)");
                letra = Convert.ToChar(Console.ReadLine());
                
                int resto = dniNum % 23;
                if (letras[resto] == letra)
                {
                    comprobante = true;
                }
                else
                {
                    comprobante = false;
                }

            } 
            string dni = dniNum + "" + letra; 
            return dni;
        }
        public static  void lectura(string ruta)
        {
            if (File.Exists(ruta))
            {
                string[] linea = File.ReadAllLines(ruta);
                foreach (string line in linea)
                {
                    string[] campos = line.Split(";");
                    libro li = new libro(campos[0], Convert.ToDateTime(campos[1]), Convert.ToDateTime(campos[2]), Convert.ToInt32(campos[3]), campos[4]);
                    libros.Add(li);

                }
            }
            

        }
        public static void lect(string a)
        {
            if (File.Exists(a))
            {
                string linea;
                StreamReader sr = new StreamReader(a);
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] campos = linea.Split(";");
                    libro li = new libro(campos[0], Convert.ToDateTime(campos[1]), Convert.ToDateTime(campos[2]), Convert.ToInt32(campos[3]), campos[4]);
                    libros.Add(li);
                }
                sr.Close();
            }
           
        }
    }
    class libro
    {
        string nombre = "aaaaaa";
        DateTime hoy = new DateTime(9999, 12, 31);
        DateTime manana  = new DateTime(9999,12, 31);
        int cantidad = 111111111;
        string dni = "AAAAA";

        public libro() { }
        public libro(string nombre, DateTime hoy, int cantidad, string dni )
        {
            this.nombre = nombre;
            this.hoy = hoy;
            this.manana = hoy.AddDays(1);
            this.cantidad = cantidad;
            this.dni = dni;
           
        }

        public libro(string nombre, DateTime hoy, DateTime manana, int cantidad, string dni)
        {
            this.nombre = nombre;
            this.hoy = hoy;
            this.manana = manana;
            this.cantidad = cantidad;
            this.dni = dni;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Hoy { get => hoy; set => hoy = value; }
        public DateTime Manana { get => manana; set => manana = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Dni { get => dni; set => dni = value; }

        override
            public string ToString()
        {
            return  "nombre: " + nombre + "  fecha: " + hoy.ToString("dd-MM-yyyy") +" +  " + manana.ToString("dd-MM-yyyy") + " cantidad: " + cantidad +  " ; " + dni;
        }
    }
}