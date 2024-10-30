using System;

class Program
{

        class Estudiante // Define la clase Estudiante
    {
        // Propiedades de la clase Estudiante
        public int Estrato { get; set; } // Propiedad pública para almacenar el estrato del estudiante
        public int Creditos { get; set; } // Propiedad pública para almacenar la cantidad de créditos del estudiante
        public double ValorCredito { get; set; } // Propiedad pública para el valor monetario de cada crédito

        // Propiedades solo accesibles desde dentro de la clase
        public double CostoMatricula { get; private set; } // Propiedad privada para almacenar el costo de la matrícula calculada
        public double Subsidio { get; private set; } // Propiedad privada para almacenar el subsidio calculado

        // Constructor que se llama cuando se crea un nuevo objeto Estudiante
        public Estudiante(int estrato, int creditos, double valorCredito)
        {
            // Asignamos valores a las propiedades de la instancia creada usando los parámetros que recibe el constructor
            Estrato = estrato;       // Se asigna el valor pasado en 'estrato' a la propiedad 'Estrato' del objeto
            Creditos = creditos;     // Se asigna el valor pasado en 'creditos' a la propiedad 'Creditos' del objeto
            ValorCredito = valorCredito; // Se asigna el valor pasado en 'valorCredito' a la propiedad 'ValorCredito' del objeto
        }

        // Método para calcular el costo de la matrícula con base en los créditos y el estrato
        public void CalcularMatricula()
        {
            // Condicional para verificar si el estudiante está tomando 20 créditos o menos
            if (Creditos <= 20)
            {
                // Si toma 20 créditos o menos, el costo se calcula multiplicando la cantidad de créditos por el valor de cada crédito
                CostoMatricula = Creditos * ValorCredito;
            }
            else
            {
                // Si toma más de 20 créditos, se calcula cuántos créditos son extra
                int creditosExtra = Creditos - 20; // creditosExtra contiene la cantidad de créditos que exceden los 20

                // Calculamos el costo de los primeros 20 créditos al valor normal
                CostoMatricula = 20 * ValorCredito;

                // Calculamos el costo de los créditos adicionales (a precio doble) y lo sumamos al costo total
                CostoMatricula += creditosExtra * ValorCredito * 2; // creditosExtra * ValorCredito * 2 calcula el costo de los créditos adicionales
            }

            // Aplica un descuento en el costo de la matrícula basado en el estrato del estudiante
            if (Estrato == 1)
            {
                CostoMatricula *= 0.2; // Aplica un descuento del 80%, quedando el 20% del costo inicial
            }
            else if (Estrato == 2)
            {
                CostoMatricula *= 0.5; // Aplica un descuento del 50%, quedando el 50% del costo inicial
            }
            else if (Estrato == 3)
            {
                CostoMatricula *= 0.7; // Aplica un descuento del 30%, quedando el 70% del costo inicial
            }
        }

        // Método para calcular el subsidio de acuerdo con el estrato
        public void CalcularSubsidio()
        {
            // Verifica el estrato para asignar el subsidio correspondiente
            if (Estrato == 1)
            {
                Subsidio = 200000; // Subsidio de $200,000 para estudiantes de estrato 1
            }
            else if (Estrato == 2)
            {
                Subsidio = 100000; // Subsidio de $100,000 para estudiantes de estrato 2
            }
            // No se asigna subsidio si el estrato es superior a 2
        }

        // Método para mostrar en pantalla el costo de matrícula y el subsidio
        public void MostrarInformacion()
        {
            // Usa Console.WriteLine para mostrar el valor calculado de matrícula
            Console.WriteLine($"Costo de matrícula: ${CostoMatricula}");
            // Usa Console.WriteLine para mostrar el subsidio calculado
            Console.WriteLine($"Subsidio: ${Subsidio}");
        }
        class Program
        {
            // Método principal Main que ejecuta el programa
            static void Main()
            {
                bool continuar = true; // Variable de control que permite al usuario repetir el proceso de cálculo

                // Bucle while que permite calcular para varios estudiantes
                while (continuar)
                {
                    // Entrada de datos para el estrato del estudiante
                    Console.Write("Ingrese el estrato del estudiante (1-3): ");
                    int estrato = int.Parse(Console.ReadLine()); // Convierte la entrada de usuario a entero y la almacena en 'estrato'

                    // Entrada de datos para la cantidad de créditos que tomará el estudiante
                    Console.Write("Ingrese la cantidad de créditos a tomar: ");
                    int creditos = int.Parse(Console.ReadLine()); // Convierte la entrada de usuario a entero y la almacena en 'creditos'

                    // Entrada de datos para el valor de cada crédito
                    Console.Write("Ingrese el valor por crédito: ");
                    double valorCredito = double.Parse(Console.ReadLine()); // Convierte la entrada de usuario a decimal y la almacena en 'valorCredito'

                    // Crear una nueva instancia de la clase Estudiante con los datos ingresados
                    Estudiante estudiante = new Estudiante(estrato, creditos, valorCredito);

                    // Llama al método CalcularMatricula para calcular el costo total de matrícula
                    estudiante.CalcularMatricula();

                    // Llama al método CalcularSubsidio para calcular el valor del subsidio
                    estudiante.CalcularSubsidio();

                    // Llama al método MostrarInformacion para imprimir en pantalla los resultados
                    estudiante.MostrarInformacion();

                    // Pregunta al usuario si desea calcular otro estudiante
                    Console.Write("¿Desea calcular la matrícula de otro estudiante? (s/n): ");
                    string respuesta = Console.ReadLine().ToLower(); // Lee la respuesta y la convierte a minúsculas

                    // Actualiza la variable de control 'continuar' según la respuesta del usuario
                    continuar = respuesta == "s"; // Si la respuesta es "s", continuará; de lo contrario, terminará el bucle
                }
            }
        }

    }

}

