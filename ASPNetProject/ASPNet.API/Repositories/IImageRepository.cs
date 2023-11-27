using ASPNet.API.Models.Domain;

namespace ASPNet.API.Repositories;

public interface IImageRepository
{
    Task<Image> Upload(Image image);
}