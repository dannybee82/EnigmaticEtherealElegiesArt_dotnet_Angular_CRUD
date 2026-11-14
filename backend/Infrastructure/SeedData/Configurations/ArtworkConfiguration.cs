using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData.Configurations
{
    public class ArtworkConfiguration : IEntityTypeConfiguration<Artwork>
    {
        public void Configure(EntityTypeBuilder<Artwork> builder)
        {
            builder.HasData(
                new Artwork()
                {
                    Id = 1,
                    Name = "The birth of Olivia des Beauchamps from a Violet Lotus",
                    Description = "The artwork depicts the birth of Olivia des Beauchamps, wearing a stunning white dress, emerging from a violet lotus beneath the full moon.",
                    ArtistId = 1,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 2,
                    Name = "Olivia des Beauchamps is wearing an 18th-century dress",
                    Description = "The artwork depicts Olivia des Beauchamps in a magnificent 18th-century black dress adorned with silver paisley patterns. Furthermore, the piece is rich in detail, including a luminous candelabra.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 3,
                    Name = "Olivia des Beauchamps walks through the Palace Hall",
                    Description = "The image shows Olivia des Beauchamps in a luxurious 18th-century dress walking through the white-marble hall of a palace.",
                    ArtistId = 3,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 4,
                    Name = "Olivia des Beauchamps is standing on the Swing in the Forest",
                    Description = "The artwork depicts Olivia des Beauchamps — a true master of balance — standing on a swing in the forest, wearing a red dress and red high heels.",
                    ArtistId = 1,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 5,
                    Name = "It is bedtime for Olivia des Beauchamps",
                    Description = "The image shows Olivia des Beauchamps in evening attire, in the middle of the night, getting ready to go to bed.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 6,
                    Name = "The Jester Queen",
                    Description = "This artwork depicts a true Jester Queen, dressed in motley attire and with a colorful necklace, presumably standing at a fairground.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 7,
                    Name = "The Jester Queen at the Fairground",
                    Description = "This artwork depicts the Jester Queen in her natural habitat: she is at a bustling fairground, with a ferris wheel in the background and a carousel at the right.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 8,
                    Name = "To be a Princess for one Day",
                    Description = "This artwork depicts a woman in a cute pink dress, spreading the dress out with both her left and right hand and imagining herself to be a princess.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 9,
                    Name = "A Quiet Hour in May",
                    Description = "This artwork depicts a woman lying in a field of pink flowers on a sunny day in May. The artist Frederick Quill has managed to capture the mood of that day very well.",
                    ArtistId = 1,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 10,
                    Name = "Noblewoman wearing an 18th-century red dress in her Bedroom",
                    Description = "This artwork depicts a beautiful noblewoman with black hair, wearing an 18th-century red dress, sitting on the bed in her bedroom.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 11,
                    Name = "Portrait of an Unknown Noblewoman",
                    Description = "This portrait — executed in pen and ink — depicts an unknown noblewoman wearing an exquisite 17th-century black dress, richly adorned with gold and red floral motifs.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 12,
                    Name = "All Flowers remember Her",
                    Description = "This artwork depicts a muse from antiquity surrounded by red roses and white lilies. There are classical columns in the background.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 13,
                    Name = "Solitude among Blooms",
                    Description = "A beautiful woman with long brown hair and wearing a white dress, sits peacefully among the pink roses in the garden.",
                    ArtistId = 1,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 14,
                    Name = "The Lady and the Blanket",
                    Description = "This artwork depicts a beautiful woman with black hair, wearing a dark dress and wrapped in a blanket.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 15,
                    Name = "The Silent Oracle of Delos",
                    Description = "This work of art, with its light and bright colors, depicts a muse from antiquity surrounded by classical columns.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 16,
                    Name = "Portrait of Isolde de Beaumont",
                    Description = "The reinterpretation of a portrait executed in pen and ink: depicting a young Victorian woman named Isolde de Beaumont.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 17,
                    Name = "Strength in Simplicity",
                    Description = "The artwork depicts an ordinary woman with dark hair and blue eyes, wearing a blue-and-black tunic dress with two belts. It is precisely this simplicity that gives the artwork its strength.",
                    ArtistId = 3,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 18,
                    Name = "The Moonlit Siren",
                    Description = "This artwork — executed in pen and ink — shows a beautiful blonde woman in a black dress in the foreground. In the background, there is an eerie castle beneath a full moon.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 19,
                    Name = "Daughter of the Golden Field",
                    Description = "The artwork depicts a summer day in August and shows a beautiful blonde woman with blue eyes, wearing a white dress who is standing in a field of grain.",
                    ArtistId = 3,
                    ArtImageId = null
                }
                ,
                new Artwork()
                {
                    Id = 20,
                    Name = "The Last Apprentice of Avalon",
                    Description = "This artwork — executed in colorful pen and ink — depicts an elven-like woman with long, blonde hair, situated within an alchemical laboratory. On the shelves stand many colorful vials containing unknown substances.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 21,
                    Name = "Portrait of Victorian Lady Prudence Whitmore",
                    Description = "This portrait - executed in pen and ink - shows the Victorian Lady Prudence Whitmore with a pink flower in her hair.",
                    ArtistId = 1,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 22,
                    Name = "The Flowered Chapter",
                    Description = "The image—executed in pen and ink — depicts a woman in a turquoise dress in a library, intently reading a book. She is evidently imagining herself in a beautiful world filled with magnificent flowers.",
                    ArtistId = 3,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 23,
                    Name = "Another Portrait of Genevieve de Montrose",
                    Description = "This portrait is a reinterpretation of a painting, depicting a young Victorian woman named Genevieve de Montrose, dressed in a lightblue dress.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 24,
                    Name = "Victorian Lady in Turquoise Blouse",
                    Description = "This artwork is executed in pen and ink; and depicts a beautiful young Victorian woman wearing a turquoise blouse adorned with gold-colored brocade. The background complements the foreground particularly well, featuring paisley patterns.",
                    ArtistId = 1,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 25,
                    Name = "The Executive Muse",
                    Description = "This artwork (executed in pen and ink) depicts a beautiful woman with long blonde hair, dressed in a black office outfit — a black blouse, a black leather skirt, pantyhose, and high heels — sitting on an office chair.",
                    ArtistId = 3,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 26,
                    Name = "The Magic Mirror",
                    Description = "This artwork - executed in pen and ink - depicts an alluring woman standing in front of a mirror. Moreover, this artwork is rich in detail and engaging for the viewer.",
                    ArtistId = 3,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 27,
                    Name = "A Dress as White as Lightning",
                    Description = "The artwork depicts a beautiful woman with dark hair wearing a white dress; behind her is a somewhat dark cloud, which makes her white dress appear even whiter.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 28,
                    Name = "Camille de Caen - the younger sister of Caitlin",
                    Description = "This work of art shows a young woman — named Camille de Caen — who is Caitlin’s younger sister.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 29,
                    Name = "Monochrome Melancholy",
                    Description = "The artwork depicts a modern woman in a black dress and a grey coat, set against a similarly grey background. The theme of this painting is, quite clearly, melancholy.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 30,
                    Name = "Portrait of Juliette Laurent",
                    Description = "This portrait shows an ordinary woman who is incredibly beautiful and whose name is Juliette Laurent.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 31,
                    Name = "Lost Hopes at the Winter Station",
                    Description = "This work of art depicts a young woman dressed in green, waiting for a train at a misty railway station. This artwork evokes a sense of sadness.",
                    ArtistId = 1,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 32,
                    Name = "The Nocturne Sisters: Carmilla, Morgana and Seraphine de Montclair",
                    Description = "This artwork (created in pen and ink) depicts the three vampire sisters — Carmilla, Morgana, and Seraphine de Montclair — against a gothic backdrop.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 33,
                    Name = "The Last Look Before the Siege",
                    Description = "The artwork depicts a woman with long brown hair looking into the distance from the parapet of a castle. The castle is situated somewhere in the Levant and is soon to be besieged.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 34,
                    Name = "Josépine de Mauvefort dressed for the Soiree",
                    Description = "The image shows the noblewoman Joséphine de Mauvefort, wearing a magnificent blue 18th-century dress and she is ready for the evening soirée.",
                    ArtistId = 1,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 35,
                    Name = "Reflections of Forever",
                    Description = "The artwork depicts a woman with auburn hair, wearing a wedding dress and looking into the mirror. Is she the bride she has always dreamed of? It is unclear what the woman is contemplating.",
                    ArtistId = 3,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 36,
                    Name = "The Regal Figure",
                    Description = "This artwork (created using colorful pen and ink) depicts a very beautiful queen, wearing a crown and an exquisite dress. The queen is also very feminine: she has long brown hair, an hourglass figure, wide hips, and a full bust — all of which symbolize fertility.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 37,
                    Name = "Guardian Angel with a Candle",
                    Description = "The image shows a guardian angel with a radiant halo, holding a candle in her hand.",
                    ArtistId = 1,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 38,
                    Name = "The Angelic Realm",
                    Description = "The image shows an angel in light breastplate armor, with light emanating from behind her — it is a celestial scene.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 39,
                    Name = "The Angel of Light and Grace",
                    Description = "This work of art depicts an angel with white hair, white wings and white clothing, who is both graceful and a bringer of light.",
                    ArtistId = 1,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 40,
                    Name = "Heaven's Fair Face",
                    Description = "This image shows an artwork (created with pen and ink) featuring a female angel with long blonde hair. The angel has a fair and innocent face.",
                    ArtistId = 3,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 41,
                    Name = "The Vampire Queen's Candlelit Court",
                    Description = "This artwork depicts a woman from a fantasy realm: a seductive vampire queen, dressed in a red dress and black gloves, is surrounded by mirrors and candles.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 42,
                    Name = "Ebony and Gold",
                    Description = "This artwork depicts an exotic woman from a distant, sunny land, dressed in traditional black attire adorned with gold-colored brocade.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 43,
                    Name = "The Bar's Best Burden",
                    Description = "The image shows a highly alluring woman with long red hair, wearing an equally alluring black dress, sitting on a bar stool. In the background, several men can be seen sitting at the bar.",
                    ArtistId = 2,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 44,
                    Name = "The crowned Queen of the Heavens",
                    Description = "This artwork (created using colorful pen and ink) alludes to Mary as Queen of the Heavens. The piece is eclectic — incorporating a blend of different styles — and is predominantly violet, gold, and blue.",
                    ArtistId = 1,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 45,
                    Name = "The Quiet Hours of the Library",
                    Description = "This artwork (created in pen and ink) depicts a woman in a red-and-yellow dress who is in a library at night. The light sources are several candles in the background and on the bookshelves.",
                    ArtistId = 3,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 46,
                    Name = "Vigil at Midnight",
                    Description = "A mysterious artwork depicting a woman in nightgown, holding a candle in her hands",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {
                    Id = 47,
                    Name = "The Marquise in a Scarlet Dress",
                    Description = "This artwork shows an unknown marquise dressed in an exquisite 18th-century red dress adorned with flower patterns.",
                    ArtistId = 4,
                    ArtImageId = null
                },
                new Artwork()
                {                    
                    Id = 48,
                    Name = "The Lady of the Candlelit Cloister",
                    Description = "This artwork depicts a beautiful woman with brown hair, wearing an 18th-century dress, situated within a gothic cloister illuminated by candles.",
                    ArtistId = 1,
                    ArtImageId = null
                }
            );
        }
    }
}
