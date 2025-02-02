using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
{
        // 1. Valida una dirección de correo electrónico (ej. usuario@dominio.com)
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        string email = "usuario@dominio.com";
        bool isValidEmail = Regex.IsMatch(email, emailPattern);
        Console.WriteLine("correo electronico valido: " + (isValidEmail ? "si" : "no"));

        // Explicacion: el patron asegura que ->
        // ^[a-zA-Z0-9._%+-]+: comienza con letras, numeros o caracteres especiales permitidos en la parte local del correo
        // @: el simbolo "@" separa la parte local del dominio
        // [a-zA-Z0-9.-]+: la parte del dominio solo contiene letras, numeros, puntos o guiones
        // \.[a-zA-Z]{2,}$: el dominio termina con un punto seguido de al menos dos letras para la extension

        Console.WriteLine("\n--------\n");

        // 2. Valida un número de teléfono con formato de 10 dígitos (ej. 123-456-7890)
        string phonePattern = @"^\d{3}-\d{3}-\d{4}$";
        string phone = "123-456-7890";
        bool isValidPhone = Regex.IsMatch(phone, phonePattern);
        Console.WriteLine("numero de telefono valido: " + (isValidPhone ? "si" : "no"));

        // Explicacion:
        // ^\d{3}-\d{3}-\d{4}$: el patron especifica que debe tener 3 digitos, un guion, 3 digitos mas, otro guion y 4 digitos finales

        Console.WriteLine("\n--------\n");

        // 3. Valida una fecha en formato día/mes/año (ej. 29/02/2024)
        string datePattern = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$";
        string date = "29/02/2024";
        bool isValidDate = Regex.IsMatch(date, datePattern);
        Console.WriteLine("fecha valida: " + (isValidDate ? "si" : "no"));

        // Explicacion:
        // (0[1-9]|[12][0-9]|3[01]): los dias pueden ser 01-31
        // (0[1-9]|1[0-2]): los meses pueden ser 01-12
        // \d{4}: el año tiene exactamente 4 digitos

        Console.WriteLine("\n--------\n");

        // 4. Valida una dirección IP en formato IPv4 (ej. 192.168.1.1)
        string ipPattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        string ip = "192.168.1.1";
        bool isValidIP = Regex.IsMatch(ip, ipPattern);
        Console.WriteLine("direccion IP valida: " + (isValidIP ? "si" : "no"));

        // Explicacion:
        // (25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?): cada octeto de la IP puede ir de 0 a 255
        // \.: el punto como separador entre los octetos

        Console.WriteLine("\n--------\n");

        // 5. Valida un código postal de 5 dígitos (ej. 12345)
        string postalCodePattern = @"^\d{5}$";
        string postalCode = "12345";
        bool isValidPostalCode = Regex.IsMatch(postalCode, postalCodePattern);
        Console.WriteLine("codigo postal valido: " + (isValidPostalCode ? "si" : "no"));

        // Explicacion:
        // ^\d{5}$: el codigo postal debe tener exactamente 5 digitos

        Console.WriteLine("\n--------\n");

        // 6. Valida una palabra que contenga solo letras, sin números ni caracteres especiales (ej. "Hola")
        string wordPattern = @"^[a-zA-Z]+$";
        string word = "Hola";
        bool isValidWord = Regex.IsMatch(word, wordPattern);
        Console.WriteLine("palabra valida: " + (isValidWord ? "si" : "no"));

        // Explicacion:
        // ^[a-zA-Z]+$: la palabra solo puede contener letras mayusculas o minusculas

        Console.WriteLine("\n--------\n");

        // 7. Valida un número entero positivo, que puede tener más de un dígito (ej. 123)
        string numberPattern = @"^\d+$";
        string number = "123";
        bool isValidNumber = Regex.IsMatch(number, numberPattern);
        Console.WriteLine("numero entero valido: " + (isValidNumber ? "si" : "no"));

        // Explicacion:
        // ^\d+$: el numero debe contener solo digitos

        Console.WriteLine("\n--------\n");

        // 8. Valida una URL (ej. http://www.ejemplo.com/)
        string urlPattern = @"^(http|https):\/\/[a-zA-Z0-9-]+\.[a-zA-Z]{2,}$";
        string url = "http://www.ejemplo.com/";
        bool isValidURL = Regex.IsMatch(url, urlPattern);
        Console.WriteLine("URL valida: " + (isValidURL ? "si" : "no"));

        // Explicacion:
        // (http|https): la URL debe comenzar con 'http' o 'https'
        // \:\/\/: el '://'
        // [a-zA-Z0-9-]+\.[a-zA-Z]{2,}: el dominio seguido de una extension

        Console.WriteLine("\n--------\n");

        // 9. Valida un código de color hexadecimal (ej. #A3C1D7)
        string hexColorPattern = @"^#([A-Fa-f0-9]{6})$";
        string hexColor = "#A3C1D7";
        bool isValidHexColor = Regex.IsMatch(hexColor, hexColorPattern);
        Console.WriteLine("codigo de color hexadecimal valido: " + (isValidHexColor ? "si" : "no"));

        // Explicacion:
        // ^#([A-Fa-f0-9]{6})$: el codigo de color debe comenzar con '#' seguido de 6 caracteres (numeros o letras A-F)

        Console.WriteLine("\n--------\n");

        // 10. Valida un número decimal con punto (ej. 12.23)
        string decimalPattern = @"^\d+\.\d+$";
        string decimalNumber = "12.23";
        bool isValidDecimal = Regex.IsMatch(decimalNumber, decimalPattern);
        Console.WriteLine("numero decimal valido: " + (isValidDecimal ? "si" : "no"));

        // Explicacion:
        // ^\d+\.\d+$: el numero debe tener al menos un digito antes y despues del punto decimal
    }
}