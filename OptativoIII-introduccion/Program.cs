using OptativoIII_introduccion.Modelos;
using Repository.Data.Personas;
using Services.Logica;

string connectionString = "Host=localhost;port=5432;Database=optativo3;Username=postgres;Password=123456;";
PersonaService personaService = new PersonaService(connectionString);

Console.WriteLine("Ingrese: \n a - para insertar \n b - para listar");
string opcion = Console.ReadLine();

if(opcion == "a")
{
    personaService.insertar(new PersonaModel
    {
        nombre = "Juan",
        apellido = "Perez Sarela",
        cedula = "456783",
        correo = "",
        fechaNacimiento = new DateTime(1990, 05, 01),
        estado = "Activo"
    });
}
if(opcion == "b")
{
    personaService.listado().ForEach(persona => 
    Console.WriteLine(
        $"Nombre: {persona.nombre} \n " +
        $"Apellido: {persona.apellido} \n " +
        $"Cedula: {persona.cedula} \n " +
        $"Correo {persona.correo} \n " +
        $"Fecha de Nacimiento: {persona.fechaNacimiento} \n " +
        $"Estado: {persona.estado} \n "
        )
    );
}





//Persona persona = new Alumno();
//persona.imprimirResponsabilidad();


//Console.WriteLine("Imprimir colaborador que hereda la clase abstracta de Persona");
//persona = new Colaborador();
//persona.imprimirResponsabilidad();


































//using OptativoIII_introduccion.Modelos;

//Alumno alumno = new Alumno();
//Console.Write("Introduzca su nombre ");
//alumno.setNombre(Console.ReadLine());
//Console.Write("Introduzca su apellido ");
//alumno.setApellido(Console.ReadLine());
//Console.Write("Introduzca su nroCedula ");
//alumno.nroCedula = Console.ReadLine();
//Console.Write("Introduzca su Mail ");
//alumno.mail = Console.ReadLine();
//Console.Write("Introduzca su Fecha de Nacimiento ");
//alumno.fechaNacimiento = DateTime.Parse(Console.ReadLine());
//Console.WriteLine("Introduzca su semestre");
//alumno.semestre = int.Parse(Console.ReadLine());


//Console.WriteLine($"Hola, {alumno.getNombre} {alumno.getApellido()}, tu fecha de nacimiento es: {alumno.fechaNacimiento} estas cursando el {alumno.semestre} semestre");


//Colaborador colaborador = new Colaborador();
//Console.Write("Introduzca su nombre ");
//colaborador.setNombre(Console.ReadLine());
//Console.Write("Introduzca su apellido ");
//colaborador.setApellido(Console.ReadLine());
//Console.Write("Introduzca su nroCedula ");
//colaborador.nroCedula = Console.ReadLine();
//Console.Write("Introduzca su Mail ");
//colaborador.mail = Console.ReadLine();
//Console.Write("Introduzca su Fecha de Nacimiento ");
//colaborador.fechaNacimiento = DateTime.Parse(Console.ReadLine());
//Console.WriteLine("Introduzca su semestre");
//colaborador.cargo = Console.ReadLine();

//Console.WriteLine($"Hola, {colaborador.getNombre} {colaborador.getApellido()}, tu fecha de nacimiento es: {colaborador.fechaNacimiento} estas con cargo de {colaborador.cargo}");
