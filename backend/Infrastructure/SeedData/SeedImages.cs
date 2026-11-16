using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public static class SeedImages
    {

        private static List<ArtImage> images = new List<ArtImage>()
        {
            new ArtImage
            {
                // Id =1,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("001.jpeg")
            },
             new ArtImage()
             {
                 // Id =2,
                 ContentType = "image/png",
                 Image = SeedDataLoader.LoadImage("002.png")
             },
             new ArtImage()
             {
                 // Id =3,
                 ContentType = "image/png",
                 Image = SeedDataLoader.LoadImage("003.png")
             },
             new ArtImage()
             {
                 // Id =4,
                 ContentType = "image/png",
                 Image = SeedDataLoader.LoadImage("004.png")
             },
            new ArtImage()
            {
                // Id =5,
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("005.jpg")
            },
            new ArtImage()
            {
                // Id =6,
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("006.png")
            },
            new ArtImage()
            {
                // Id =7,
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("007.png")
            },
            new ArtImage()
            {
                // Id =8,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("008.jpeg")
            },
            new ArtImage()
            {
                // Id =9,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("009.jpeg")
            },
            new ArtImage()
            {
                // Id =10,
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("010.jpg")
            },
            new ArtImage()
            {
                // Id =11,
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("011.png")
            },
            new ArtImage()
            {
                // Id =12,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("012.jpeg")
            },
            new ArtImage()
            {
                // Id =13,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("013.jpeg")
            },
            new ArtImage()
            {
                // Id =14,
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("014.jpeg")
            },
            new ArtImage()
            {
                // Id =15,
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("015.jpg")
            },
            new ArtImage()
            {
                // Id =16,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("016.jpeg")
            },
            new ArtImage()
            {
                // Id =17,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("017.jpeg")
            },
            new ArtImage()
            {
                // Id =18,
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("018.png")
            },
            new ArtImage()
            {
                // Id =19,
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("019.jpg")
            },
            new ArtImage()
            {
                // Id =20,
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("020.jpg")
            },
            new ArtImage()
            {
                // Id =21,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("021.jpeg")
            },
            new ArtImage()
            {
                // Id =22,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("022.jpeg")
            },
            new ArtImage()
            {
                // Id =23,
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("023.jpg")
            },
            new ArtImage()
            {
                // Id =24,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("024.jpeg")
            },
            new ArtImage()
            {
                // Id =25,
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("025.png")
            },
            new ArtImage()
            {
                // Id =26,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("026.jpeg")
            },
            new ArtImage()
            {
                // Id =27,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("027.jpeg")
            },
            new ArtImage()
            {
                // Id =28,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("028.jpeg")
            },
            new ArtImage()
            {
                // Id =29,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("029.jpeg")
            },
            new ArtImage()
            {
                // Id =30,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("030.jpeg")
            },
            new ArtImage()
            {
                // Id =31,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("031.jpeg")
            },
            new ArtImage()
            {
                // Id =32,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("032.jpeg")
            },
            new ArtImage()
            {
                // Id =33,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("033.jpeg")
            },
            new ArtImage()
            {
                // Id =34,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("034.jpeg")
            },
            new ArtImage()
            {
                // Id =35,
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("035.png")
            },
            new ArtImage()
            {
                // Id =36,
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("036.png")
            },
            new ArtImage()
            {
                // Id =37,
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("037.jpg")
            },
            new ArtImage()
            {
                // Id =38,
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("038.png")
            },
            new ArtImage()
            {
                // Id =39,
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("039.png")
            },
            new ArtImage()
            {
                // Id =40,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("040.jpeg")
            },
            new ArtImage()
            {
                // Id =41,
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("041.png")
            },
            new ArtImage()
            {
                // Id =42,
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("042.jpg")
            },
            new ArtImage()
            {
                // Id =43,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("043.jpeg")
            },
            new ArtImage()
            {
                // Id =44,
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("044.jpg")
            },
            new ArtImage()
            {
                // Id =45,
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("045.jpg")
            },
            new ArtImage()
            {
                // Id =46,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("046.jpeg")
            },
            new ArtImage()
            {
                // Id =47,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("047.jpeg")
            },
            new ArtImage()
            {
                // Id =48,
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("048.jpeg")
            }
        };

        public static async Task SeedAsync(AppDbContext db)
        {
            int count = await db.ArtImages.Select(x => x.Id).CountAsync();

            if (count == 0)
            {
                // Traverse Artworks and set ArtImage Id's.
                var artworks = await db.Artworks.ToListAsync();

                if (artworks.Count() == images.Count())
                {
                    for (int i = 0; i < artworks.Count(); i++)
                    {
                        var image = images[i];
                        artworks[i].ArtImage = image;
                        db.Artworks.Update(artworks[i]);
                        await db.SaveChangesAsync();
                    }
                }
            }
        }

    }
}
