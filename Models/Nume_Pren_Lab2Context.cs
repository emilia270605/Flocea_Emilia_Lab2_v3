using Flocea_Emilia_Lab2_v3.Models;

namespace Nume_Pren_Lab2.Models
{
    public class Nume_Pren_Lab2Context
    {
        public IEnumerable<object> Category { get; internal set; }

        internal void Remove(BookCategory bookToRemove)
        {
            throw new NotImplementedException();
        }
    }
}