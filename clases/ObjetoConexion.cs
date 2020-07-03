//Insertar
//Modificar
//Borrado
//Consultas con filtros
public interface ObjetoConexion {
   
        internal Conexion Con { get;set; }
        
        private ControlAlumnos()
        {
            Con = new ConexionPg();
            Alumnos = new List<Alumno>();
            
        }

        public static ControlAlumnos Instance
        {
            get
            {
                if (instance == null)
                    instance = new this();
                return instance;
            }
        }

        public DataTable SearchAll()
        {
        	string consulta ="SELECT * FROM \"ISAUI\".alumno ORDER BY codalumno ASC";
            var temAlumno = new List<Alumno>();
            temAlumno = (List<Alumno>)Instance.Con.consultaList<Alumno>(consulta);
            this.Alumnos  = temAlumno;
            return Instance.Con.consultaDataTable(consulta);
        }
       

        public void Insert(object<T> parametro)
        {	
        	String consulta = "INSERT INTO \"ISAUI\".alumno (nombre, apellido, nroDocumento, email, celular) VALUES (@NOMBRE, @APELLIDO, @NRODOCUMENTO, @EMAIL, @CELULAR)";
        	List<NpgsqlParameter> param =new List<NpgsqlParameter>();
        	param.Add(new NpgsqlParameter ("NOMBRE",parametro .Nombre ));
        	param.Add(new NpgsqlParameter ("APELLIDO",parametro .Apellido  ));
        	param.Add(new NpgsqlParameter ("NRODOCUMENTO",parametro .NroDocumento  ));
        	param.Add(new NpgsqlParameter ("EMAIL",parametro .Email ));
        	param.Add(new NpgsqlParameter ("CELULAR",parametro .Celular  ));
        	Instance.Con.ConsultaParametros(consulta,param);
            

        }
        public void Update(Alumno parametro)
        {
            String consulta = "UPDATE  \"ISAUI\".alumno SET nombre = @NOMBRE, apellido = @APELLIDO, nrodocumento = @NRODOCUMENTO, email = @EMAIL, celular= @CELULAR WHERE codalumno = @CODALUMNO";
            List<NpgsqlParameter> param = new List<NpgsqlParameter>();
            param.Add(new NpgsqlParameter("NOMBRE", parametro.Nombre));
            param.Add(new NpgsqlParameter("APELLIDO", parametro.Apellido));
            param.Add(new NpgsqlParameter("NRODOCUMENTO", parametro.NroDocumento));
            param.Add(new NpgsqlParameter("EMAIL", parametro.Email));
            param.Add(new NpgsqlParameter("CELULAR", parametro.Celular));
            param.Add(new NpgsqlParameter("CODALUMNO", parametro.codAlumno));
            Instance.Con.ConsultaParametros(consulta, param);


        }
        public void Delete(int parametro)
        {
            String consulta = "DELETE FROM \"ISAUI\".alumno WHERE codalumno = @CODALUMNO";
            List<NpgsqlParameter> param = new List<NpgsqlParameter>();
            param.Add(new NpgsqlParameter("CODALUMNO", parametro));
            Instance.Con.ConsultaParametros(consulta, param);
        }

        public Alumno SearchId(int id) {
            Alumno retorna;
            string consulta = "SELECT * FROM \"ISAUI\".alumno Where codalumno = "+id;
            var temAlumno = new List<Alumno>();
            temAlumno = (List<Alumno>)Instance.Con.consultaList<Alumno>(consulta);
            retorna = temAlumno[0];
            return retorna;
        }

       
            
        
}