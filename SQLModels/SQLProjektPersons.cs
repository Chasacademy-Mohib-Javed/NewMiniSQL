using System;

namespace MiniProjektSQL.Models
{
    public class SQLProjektPerson
    {
        public int Id { get; set; }
        public int project_Id { get; set; }
        public int person_Id { get; set; }
        public string? person_name { get; set; }
        public string? project_name { get; set; }
        public int hours { get; set; }   
    }
}