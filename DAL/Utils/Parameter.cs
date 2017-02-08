namespace DAL.Utils
{
    public class Parameter<T> 
    {

        public string Name { get; set; }

        public T Value { get; set; }

        public Parameter(string name)
        {
            this.Name = name;
        }

        public Parameter(string name, T value)
        {
            this.Name = name;
            this.Value = value;
        }

        public Parameter()
        {
           
        }
    }
    
}
