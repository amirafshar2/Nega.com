﻿using Microsoft.AspNetCore.Http;
using System;

namespace Negacom.Areas.Admin.Models
{


    public class BlogModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile? Picture { get; set; }
        public IFormFile? Picture2 { get; set; }
        public IFormFile? Picture3 { get; set; }
        public IFormFile? Picture4 { get; set; }
        public IFormFile? Picture5 { get; set; }
        public IFormFile? Picture6 { get; set; }
        public IFormFile? Picture7 { get; set; }
        public IFormFile? Picture8 { get; set; }
        public IFormFile? Picture9 { get; set; }
        public IFormFile? Picture10 { get; set; }
        public string strPicture { get; set; }
        public string strPicture2 { get; set; }
        public string strPicture3 { get; set; }
        public string strPicture4 { get; set; }
        public string strPicture5 { get; set; }
        public string strPicture6 { get; set; }
        public string strPicture7 { get; set; }
        public string strPicture8 { get; set; }
        public string strPicture9 { get; set; }
        public string strPicture10 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string Title4 { get; set; }
        public string Title5 { get; set; }
        public string Title6 { get; set; }
        public string Title7 { get; set; }
        public string Title8 { get; set; }
        public string Title9 { get; set; }
        public string Title10 { get; set; }
        public string? Content2 { get; set; }
        public string? Content3 { get; set; }
        public string? Content4 { get; set; }
        public string? Content5 { get; set; }
        public string? Content6 { get; set; }
        public string? Content7 { get; set; }
        public string? Content8 { get; set; }
        public string? Content9 { get; set; }
        public string? Content10 { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int categoryid {  get; set; }
        public int userid { get; set; }

    }
}
