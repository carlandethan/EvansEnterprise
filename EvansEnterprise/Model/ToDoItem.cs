using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EvansEnterprise.Model
{
    public class ToDoItem
    {
        [Key] 
        public int? ToDoItemId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

    }
}
