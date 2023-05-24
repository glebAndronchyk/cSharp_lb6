namespace LB6.Models
{
    public struct SwapiChar
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string eye_color { get; set; }

        public override string ToString()
        {
            return $"Name: {name}\nHeight: {height}\nMass: {mass}\nHair Color: {hair_color}\nEye Color: {eye_color}";
        }
    }
}