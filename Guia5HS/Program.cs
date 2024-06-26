namespace Guia5HS{
    public class Telefono
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public void MostrarInformacion()
        {Console.WriteLine($"Marca: {Marca}, Modelo: {Modelo}, Precio: ${Precio}, Stock: {Stock}");

        }

    }

    public class TelefonoInteligente : Telefono
    {
        public string SistemaOperativo { get; set; }
        public int MemoriaRam { get; set; }

        public void MostrarInformacionTelefonoInteligente()
        {
            MostrarInformacion();
            Console.WriteLine($"Sistema Operativo: {SistemaOperativo}, Memoria RAM: {MemoriaRam} GB");
        }
    }

    public class TelefonoBasico : Telefono
    {
        public bool TieneRadioFM { get; set; }
        public bool TieneLinterna { get; set; }

        public void MostrarInformacionTelefonoBasico() {
            MostrarInformacion();
            Console.WriteLine($"Tiene Radio FM: {TieneRadioFM}, Tiene Linterna: {TieneLinterna}");
        }
    }

    class program
    {
        static List<Telefono> telefonosRegistrados = new List<Telefono>(); // List to store registered phones

        static void Main(string[] args)
        {
            telefonosRegistrados = new List<Telefono>();
            bool salir = false;

            while (!salir)
            {
                Console.Clear(); // Clear the console before displaying the menu
                Console.WriteLine("\n**Menú de Gestión de Inventario de Teléfonos**");
                Console.WriteLine("1. Registrar Teléfono");
                Console.WriteLine("2. Mostrar Teléfonos Registrados");
                Console.WriteLine("3. Consultar Stock de un Teléfono");
                Console.WriteLine("4. Salir");

                Console.Write("\nIngrese su opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarTelefono();
                        break;
                    case 2:
                        MostrarTelefonosRegistrados();
                        break;
                    case 3:
                        ConsultarStockTelefono();
                        break;
                    case 4:
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Intente nuevamente.");
                        break;
                }
            }
        }
        static void RegistrarTelefono()
        {
            Console.Write("\n¿Qué tipo de teléfono desea registrar? (1. Inteligente, 2. Básico): ");
            int tipoTelefono = int.Parse(Console.ReadLine());

            Console.Write("\nIngrese la marca del teléfono: ");
            string marca = Console.ReadLine();

            Console.Write("\nIngrese el modelo del teléfono: ");
            string modelo = Console.ReadLine();

            Console.Write("\nIngrese el precio del teléfono: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.Write("\nIngrese la cantidad en stock del teléfono: ");
            int stock = int.Parse(Console.ReadLine());

            if (tipoTelefono == 1) // Registrar teléfono inteligente
            {
                Console.Write("\nIngrese el sistema operativo del teléfono inteligente: ");
                string sistemaOperativo = Console.ReadLine();

                Console.Write("\nIngrese la cantidad de memoria RAM del teléfono inteligente (en GB): ");
                int memoriaRam = int.Parse(Console.ReadLine());

                TelefonoInteligente nuevoSmartphone = new TelefonoInteligente()
                {
                    Marca = marca,
                    Modelo = modelo,
                    Precio = precio,
                    Stock = stock,
                    SistemaOperativo = sistemaOperativo,
                    MemoriaRam = memoriaRam
                };

                telefonosRegistrados.Add(nuevoSmartphone);
                Console.WriteLine("\nTeléfono inteligente registrado exitosamente.");
            }
            else if (tipoTelefono == 2) // Registrar teléfono básico
            {
                Console.Write("\n¿Tiene radio FM el teléfono básico? (1. Sí, 2. No): ");
                int tieneRadioFM = int.Parse(Console.ReadLine());
                bool radioFM = tieneRadioFM == 1;

                Console.Write("\n¿Tiene linterna el teléfono básico? (1. Sí, 2. No): ");
                int tieneLinterna = int.Parse(Console.ReadLine());
                bool linterna = tieneLinterna == 1;

                TelefonoBasico nuevoTelefonoBasico = new TelefonoBasico()
                {
                    Marca = marca,
                    Modelo = modelo,
                    Precio = precio,
                    Stock = stock,
                    TieneRadioFM = radioFM,
                    TieneLinterna = linterna
                };

                telefonosRegistrados.Add(nuevoTelefonoBasico);
                Console.WriteLine("\nTeléfono básico registrado exitosamente.");
            }
            else
            {
                Console.WriteLine("\nTipo de teléfono no válido.");
            }
        }

        static void MostrarTelefonosRegistrados()
        {
            if (telefonosRegistrados.Count == 0)
            {
                Console.WriteLine("\nNo hay teléfonos registrados en el sistema.");
                Console.WriteLine("Presione Una tecla para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\n**Lista de Teléfonos Registrados**");
            foreach (Telefono telefono in telefonosRegistrados)
            {
                if (telefono is TelefonoInteligente)
                {
                    ((TelefonoInteligente)telefono).MostrarInformacionTelefonoInteligente();
                    Console.WriteLine("Presione Una tecla para continuar...");
                    Console.ReadLine();
                }
                else if (telefono is TelefonoBasico)
                {
                    ((TelefonoBasico)telefono).MostrarInformacionTelefonoBasico();
                    Console.WriteLine("Presione Una tecla para continuar...");
                    Console.ReadLine();
                }
            }
        }
        static void ConsultarStockTelefono()
        {
            Console.Write("\nIngrese el modelo del teléfono para verificar su stock: ");
            string modeloBuscado = Console.ReadLine();

            bool telefonoEncontrado = false;
            int stockEncontrado = 0;

            foreach (Telefono telefono in telefonosRegistrados)
            {
                if (telefono.Modelo == modeloBuscado)
                {
                    stockEncontrado = telefono.Stock;
                    telefonoEncontrado = true;
                    break;
                }
            }

            if (telefonoEncontrado)
            {
                Console.WriteLine($"\nEl teléfono {modeloBuscado} tiene {stockEncontrado} unidades en stock.");
                Console.WriteLine("Presione Una tecla para continuar...");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine($"\nNo se encontró el teléfono {modeloBuscado} en el sistema.");
                Console.WriteLine("Presione Una tecla para continuar...");
                Console.ReadLine();
            }
        }
    }

}
