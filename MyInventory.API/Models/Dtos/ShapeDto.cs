namespace MyInventory.API.Models.Dtos
{
    public class ShapeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }

        public static ShapeDto ToDto(Shape shape)
        {
            return new ShapeDto()
            {
                Id = shape.Id,
                Name = shape.Name,
                Width = shape.Width,
                Length = shape.Length,
            };
        }
    }
}
