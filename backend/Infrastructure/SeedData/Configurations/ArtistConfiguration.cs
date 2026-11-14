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
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasData(
                new Artist()
                {
                    Id = 1,
                    Name = "Frederick Quill",
                    Description = "The movement's undisputed master of the pen, Quill trained as an engraver before turning to wash drawing. His portraits of women dancing alone in empty rooms — most famously The Unwitnessed Waltz — paired razor-sharp contour lines with watery lavender shadows. He insisted on cutting his own quills from raven feathers, claiming steel nibs \"shouted where one should murmur\".",
                    YearOfBirth = 1982,
                    YearOfDeath = null
                },
                new Artist()
                {
                    Id = 2,
                    Name = "Sören Blauberg",
                    Description = "Blauberg was the colorist of the group, renowned for exhausting every nuance of diluted Prussian blue. His women appear in fog, rain, or dusk — faces half-dissolved into washes that seem lit from within, as in his beloved Ladies by the Northern Sea. Scandinavian critics called him \"the painter of blue silence.\"",
                    YearOfBirth = 1981,
                    YearOfDeath = null
                },
                new Artist()
                {
                    Id = 3,
                    Name = "Hugh Silverstone",
                    Description = "A former stained-glass apprentice, Silverstone brought a craftsman's patience to the movement, building portraits from hundreds of whisper-thin translucent layers. His best-known piece, The Silver Sitting rendered a woman in greys so luminous she seemed backlit by moonlight. Late in life he taught the movement's technique to a generation of younger devotees.",
                    YearOfBirth = 1982,
                    YearOfDeath = null
                },
                new Artist()
                {
                    Id = 4,
                    Name = "Bertram Hillman",
                    Description = "The eldest of the four, Hillman came to aquarelle after years painting theatrical backdrops, giving his works an unusually atmospheric stage-like quality. His women gaze directly at the viewer with calm, knowing eyes amid deep umbers and faded roses — Portrait of a Lady at Dusk remains his defining image. He was the unofficial chronicler of the movement's meetings, keeping meticulous sketch-journals now prized by collectors.",
                    YearOfBirth = 1980,
                    YearOfDeath = null
                }
            );
        }
    }
}
