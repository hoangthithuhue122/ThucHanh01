using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace HtthLab01.Models

{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Họ tên")]
        [StringLength(100, MinimumLength = 4)]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi @gmail.com")]
        public string? Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(100, MinimumLength = 8)]
        [Required]
        public string? Password { get; set; }

        [Display(Name = "Khoa")]
        [Required]
        public Branch? Branch { get; set; }

        [Display(Name = "Giới tính")]
        [Required]
        public Gender? Gender { get; set; }

        [Display(Name = "Hệ chính quy")]
        public bool IsRegular { get; set; }

        [Display(Name = "Địa chỉ")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string? Address { get; set; }

        [Display(Name = "Ngày tháng năm sinh")]
        [Range(typeof(DateTime), "1/1/1963", "12/31/2008")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string? AvatarUrl { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public IFormFile? AvatarFile { get; set; }
    }
}
