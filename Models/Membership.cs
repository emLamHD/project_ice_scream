using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoDataFirst.Models;
[Table("memberships")] // Ánh xạ với bảng "users" trong cơ sở dữ liệu
public partial class Membership
{
    [Key]
    [Column("MembershipID")] // Ánh xạ với cột "" trong cơ sở dữ liệu
    public int MembershipId { get; set; }

    [Column("UserID")] // Ánh xạ với cột "UserID" trong cơ sở dữ liệu
    public int? UserId { get; set; }

    [Required(ErrorMessage = "Type is required.")]
    [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
    public string Type { get; set; } = null!;

    [Required(ErrorMessage = "Start date is required.")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid start date format.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is required.")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid end date format.")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, 9999999.99, ErrorMessage = "Price must be between 0.01 and 9,999,999.99.")]
    public decimal Price { get; set; }
}
