﻿namespace ApiProjeKamp.WebUI.Dtos.ChefDtos
{
    public class UpdateChefDto
    {
        public int ChefId { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
