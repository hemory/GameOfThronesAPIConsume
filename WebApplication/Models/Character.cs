using System.Collections.Generic;

namespace WebApplication.Models
{
    public class CharacterResponse
    {
        private List<Character> cards { get; set; }
    }
    public class Character
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string[] PlayedBy { get; set; }
    }
}