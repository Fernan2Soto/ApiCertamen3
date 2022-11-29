namespace APIWeb
{
    public record DepartamentosDTO(int cod_departamento, string nombre_departamento, string direccion, string ciudad);
    public record CargosDTO(int cod_cargo, string nombre_cargo);
    public record EmpleadosDTO(string rut, string nombre_empleado, string apellidos_empleados, int cod_cargo, string rut_jefe );
    public record JefesDTO(string rut, string nombre_jefe, string apellidos_jefe, int id_departamento);

}
