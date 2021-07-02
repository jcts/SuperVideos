using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace SuperVideos.Application.Models
{
    public class MovieViewModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Display(Name = "Título")]
        [Required(ErrorMessage = "Informe o título do Filme")]
        public string Title { get; set; }

        [MaxLength(50)]
        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "Informe o Gênero do Filme")]
        public string Gender { get; set; }

        [MaxLength(300)]
        [Display(Name = "Sinopse")]
        [Required(ErrorMessage = "Informe a Sinopse do Filme")]
        public string Synopsis { get; set; }

        public IFormFile _sleeve { get; set; }

        [ScaffoldColumn(false)]
        public IFormFile Sleeve
        {
            get
            {
                return _sleeve;
            }
            set
            {
                _sleeve = value;

                if (value != null)
                {
                    using var stream = new MemoryStream();
                    value.CopyTo(stream);

                    ContenType = value.ContentType;

                    SleeveContent = stream.ToArray();
                }
            }
        }

        [ScaffoldColumn(false)]
        public byte[] SleeveContent { get; set; }

        [ScaffoldColumn(false)]
        public string ContenType { get; set; }

        [ScaffoldColumn(false)]
        public bool Available { get; set; } = true;

        [Display(Name = "Código de Barras")]
        [Required(ErrorMessage = "Informe o Código de Barras do Filme")]
        public long BarCode { get; set; }

        [Display(Name = "Duração em Minutos")]
        [Required(ErrorMessage = "Informe o Duração do Filme")]
        public int Duration { get; set; }

        [Display(Name = "Código ISBN")]
        [Required(ErrorMessage = "Informe o código ISBN do Filme")]
        public long Isbn { get; set; }

        [MaxLength(300)]
        [Display(Name = "Código Interno")]
        [Required(ErrorMessage = "Informe o código Interndo do Filme")]
        public string Code { get; set; }
    }

}
