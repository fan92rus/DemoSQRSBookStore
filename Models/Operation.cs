using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Operation<T> : Operation
    {
        public Operation(bool success, string errors, T value) : base(success, errors)
        {
            this.Value = value;
        }
        public Operation(bool success, IEnumerable<string> errors, T value) : base(success, errors)
        {
            this.Value = value;
        }

        public T Value { get; set; }
    }
    public class Operation
    {
        public Operation(bool success, string error) : this(success)
        {
            this.Errors = new List<string>() { error };
        }
        public Operation(bool success, IEnumerable<string> errors) : this(success)
        {
            this.Errors = errors;
        }
        public Operation(bool success)
        {
            Success = success;
        }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
