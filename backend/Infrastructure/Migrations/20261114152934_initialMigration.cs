using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EnigmaticEtherealElegiesArt");

            migrationBuilder.CreateTable(
                name: "ArtImages",
                schema: "EnigmaticEtherealElegiesArt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                schema: "EnigmaticEtherealElegiesArt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    YearOfBirth = table.Column<int>(type: "integer", nullable: true),
                    YearOfDeath = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artworks",
                schema: "EnigmaticEtherealElegiesArt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: true),
                    ArtImageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artworks_ArtImages_ArtImageId",
                        column: x => x.ArtImageId,
                        principalSchema: "EnigmaticEtherealElegiesArt",
                        principalTable: "ArtImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Artworks_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalSchema: "EnigmaticEtherealElegiesArt",
                        principalTable: "Artists",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "EnigmaticEtherealElegiesArt",
                table: "Artists",
                columns: new[] { "Id", "Description", "Name", "YearOfBirth", "YearOfDeath" },
                values: new object[,]
                {
                    { 1, "The movement's undisputed master of the pen, Quill trained as an engraver before turning to wash drawing. His portraits of women dancing alone in empty rooms — most famously The Unwitnessed Waltz — paired razor-sharp contour lines with watery lavender shadows. He insisted on cutting his own quills from raven feathers, claiming steel nibs \"shouted where one should murmur\".", "Frederick Quill", 1982, null },
                    { 2, "Blauberg was the colorist of the group, renowned for exhausting every nuance of diluted Prussian blue. His women appear in fog, rain, or dusk — faces half-dissolved into washes that seem lit from within, as in his beloved Ladies by the Northern Sea. Scandinavian critics called him \"the painter of blue silence.\"", "Sören Blauberg", 1981, null },
                    { 3, "A former stained-glass apprentice, Silverstone brought a craftsman's patience to the movement, building portraits from hundreds of whisper-thin translucent layers. His best-known piece, The Silver Sitting rendered a woman in greys so luminous she seemed backlit by moonlight. Late in life he taught the movement's technique to a generation of younger devotees.", "Hugh Silverstone", 1982, null },
                    { 4, "The eldest of the four, Hillman came to aquarelle after years painting theatrical backdrops, giving his works an unusually atmospheric stage-like quality. His women gaze directly at the viewer with calm, knowing eyes amid deep umbers and faded roses — Portrait of a Lady at Dusk remains his defining image. He was the unofficial chronicler of the movement's meetings, keeping meticulous sketch-journals now prized by collectors.", "Bertram Hillman", 1980, null }
                });

            migrationBuilder.InsertData(
                schema: "EnigmaticEtherealElegiesArt",
                table: "Artworks",
                columns: new[] { "Id", "ArtImageId", "ArtistId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, "The artwork depicts the birth of Olivia des Beauchamps, wearing a stunning white dress, emerging from a violet lotus beneath the full moon.", "The birth of Olivia des Beauchamps from a Violet Lotus" },
                    { 2, null, 4, "The artwork depicts Olivia des Beauchamps in a magnificent 18th-century black dress adorned with silver paisley patterns. Furthermore, the piece is rich in detail, including a luminous candelabra.", "Olivia des Beauchamps is wearing an 18th-century dress" },
                    { 3, null, 3, "The image shows Olivia des Beauchamps in a luxurious 18th-century dress walking through the white-marble hall of a palace.", "Olivia des Beauchamps walks through the Palace Hall" },
                    { 4, null, 1, "The artwork depicts Olivia des Beauchamps — a true master of balance — standing on a swing in the forest, wearing a red dress and red high heels.", "Olivia des Beauchamps is standing on the Swing in the Forest" },
                    { 5, null, 4, "The image shows Olivia des Beauchamps in evening attire, in the middle of the night, getting ready to go to bed.", "It is bedtime for Olivia des Beauchamps" },
                    { 6, null, 2, "This artwork depicts a true Jester Queen, dressed in motley attire and with a colorful necklace, presumably standing at a fairground.", "The Jester Queen" },
                    { 7, null, 4, "This artwork depicts the Jester Queen in her natural habitat: she is at a bustling fairground, with a ferris wheel in the background and a carousel at the right.", "The Jester Queen at the Fairground" },
                    { 8, null, 4, "This artwork depicts a woman in a cute pink dress, spreading the dress out with both her left and right hand and imagining herself to be a princess.", "To be a Princess for one Day" },
                    { 9, null, 1, "This artwork depicts a woman lying in a field of pink flowers on a sunny day in May. The artist Frederick Quill has managed to capture the mood of that day very well.", "A Quiet Hour in May" },
                    { 10, null, 2, "This artwork depicts a beautiful noblewoman with black hair, wearing an 18th-century red dress, sitting on the bed in her bedroom.", "Noblewoman wearing an 18th-century red dress in her Bedroom" },
                    { 11, null, 4, "This portrait — executed in pen and ink — depicts an unknown noblewoman wearing an exquisite 17th-century black dress, richly adorned with gold and red floral motifs.", "Portrait of an Unknown Noblewoman" },
                    { 12, null, 2, "This artwork depicts a muse from antiquity surrounded by red roses and white lilies. There are classical columns in the background.", "All Flowers remember Her" },
                    { 13, null, 1, "A beautiful woman with long brown hair and wearing a white dress, sits peacefully among the pink roses in the garden.", "Solitude among Blooms" },
                    { 14, null, 2, "This artwork depicts a beautiful woman with black hair, wearing a dark dress and wrapped in a blanket.", "The Lady and the Blanket" },
                    { 15, null, 4, "This work of art, with its light and bright colors, depicts a muse from antiquity surrounded by classical columns.", "The Silent Oracle of Delos" },
                    { 16, null, 2, "The reinterpretation of a portrait executed in pen and ink: depicting a young Victorian woman named Isolde de Beaumont.", "Portrait of Isolde de Beaumont" },
                    { 17, null, 3, "The artwork depicts an ordinary woman with dark hair and blue eyes, wearing a blue-and-black tunic dress with two belts. It is precisely this simplicity that gives the artwork its strength.", "Strength in Simplicity" },
                    { 18, null, 2, "This artwork — executed in pen and ink — shows a beautiful blonde woman in a black dress in the foreground. In the background, there is an eerie castle beneath a full moon.", "The Moonlit Siren" },
                    { 19, null, 3, "The artwork depicts a summer day in August and shows a beautiful blonde woman with blue eyes, wearing a white dress who is standing in a field of grain.", "Daughter of the Golden Field" },
                    { 20, null, 4, "This artwork — executed in colorful pen and ink — depicts an elven-like woman with long, blonde hair, situated within an alchemical laboratory. On the shelves stand many colorful vials containing unknown substances.", "The Last Apprentice of Avalon" },
                    { 21, null, 1, "This portrait - executed in pen and ink - shows the Victorian Lady Prudence Whitmore with a pink flower in her hair.", "Portrait of Victorian Lady Prudence Whitmore" },
                    { 22, null, 3, "The image—executed in pen and ink — depicts a woman in a turquoise dress in a library, intently reading a book. She is evidently imagining herself in a beautiful world filled with magnificent flowers.", "The Flowered Chapter" },
                    { 23, null, 2, "This portrait is a reinterpretation of a painting, depicting a young Victorian woman named Genevieve de Montrose, dressed in a lightblue dress.", "Another Portrait of Genevieve de Montrose" },
                    { 24, null, 1, "This artwork is executed in pen and ink; and depicts a beautiful young Victorian woman wearing a turquoise blouse adorned with gold-colored brocade. The background complements the foreground particularly well, featuring paisley patterns.", "Victorian Lady in Turquoise Blouse" },
                    { 25, null, 3, "This artwork (executed in pen and ink) depicts a beautiful woman with long blonde hair, dressed in a black office outfit — a black blouse, a black leather skirt, pantyhose, and high heels — sitting on an office chair.", "The Executive Muse" },
                    { 26, null, 3, "This artwork - executed in pen and ink - depicts an alluring woman standing in front of a mirror. Moreover, this artwork is rich in detail and engaging for the viewer.", "The Magic Mirror" },
                    { 27, null, 4, "The artwork depicts a beautiful woman with dark hair wearing a white dress; behind her is a somewhat dark cloud, which makes her white dress appear even whiter.", "A Dress as White as Lightning" },
                    { 28, null, 2, "This work of art shows a young woman — named Camille de Caen — who is Caitlin’s younger sister.", "Camille de Caen - the younger sister of Caitlin" },
                    { 29, null, 4, "The artwork depicts a modern woman in a black dress and a grey coat, set against a similarly grey background. The theme of this painting is, quite clearly, melancholy.", "Monochrome Melancholy" },
                    { 30, null, 2, "This portrait shows an ordinary woman who is incredibly beautiful and whose name is Juliette Laurent.", "Portrait of Juliette Laurent" },
                    { 31, null, 1, "This work of art depicts a young woman dressed in green, waiting for a train at a misty railway station. This artwork evokes a sense of sadness.", "Lost Hopes at the Winter Station" },
                    { 32, null, 2, "This artwork (created in pen and ink) depicts the three vampire sisters — Carmilla, Morgana, and Seraphine de Montclair — against a gothic backdrop.", "The Nocturne Sisters: Carmilla, Morgana and Seraphine de Montclair" },
                    { 33, null, 2, "The artwork depicts a woman with long brown hair looking into the distance from the parapet of a castle. The castle is situated somewhere in the Levant and is soon to be besieged.", "The Last Look Before the Siege" },
                    { 34, null, 1, "The image shows the noblewoman Joséphine de Mauvefort, wearing a magnificent blue 18th-century dress and she is ready for the evening soirée.", "Josépine de Mauvefort dressed for the Soiree" },
                    { 35, null, 3, "The artwork depicts a woman with auburn hair, wearing a wedding dress and looking into the mirror. Is she the bride she has always dreamed of? It is unclear what the woman is contemplating.", "Reflections of Forever" },
                    { 36, null, 4, "This artwork (created using colorful pen and ink) depicts a very beautiful queen, wearing a crown and an exquisite dress. The queen is also very feminine: she has long brown hair, an hourglass figure, wide hips, and a full bust — all of which symbolize fertility.", "The Regal Figure" },
                    { 37, null, 1, "The image shows a guardian angel with a radiant halo, holding a candle in her hand.", "Guardian Angel with a Candle" },
                    { 38, null, 2, "The image shows an angel in light breastplate armor, with light emanating from behind her — it is a celestial scene.", "The Angelic Realm" },
                    { 39, null, 1, "This work of art depicts an angel with white hair, white wings and white clothing, who is both graceful and a bringer of light.", "The Angel of Light and Grace" },
                    { 40, null, 3, "This image shows an artwork (created with pen and ink) featuring a female angel with long blonde hair. The angel has a fair and innocent face.", "Heaven's Fair Face" },
                    { 41, null, 4, "This artwork depicts a woman from a fantasy realm: a seductive vampire queen, dressed in a red dress and black gloves, is surrounded by mirrors and candles.", "The Vampire Queen's Candlelit Court" },
                    { 42, null, 4, "This artwork depicts an exotic woman from a distant, sunny land, dressed in traditional black attire adorned with gold-colored brocade.", "Ebony and Gold" },
                    { 43, null, 2, "The image shows a highly alluring woman with long red hair, wearing an equally alluring black dress, sitting on a bar stool. In the background, several men can be seen sitting at the bar.", "The Bar's Best Burden" },
                    { 44, null, 1, "This artwork (created using colorful pen and ink) alludes to Mary as Queen of the Heavens. The piece is eclectic — incorporating a blend of different styles — and is predominantly violet, gold, and blue.", "The crowned Queen of the Heavens" },
                    { 45, null, 3, "This artwork (created in pen and ink) depicts a woman in a red-and-yellow dress who is in a library at night. The light sources are several candles in the background and on the bookshelves.", "The Quiet Hours of the Library" },
                    { 46, null, 4, "A mysterious artwork depicting a woman in nightgown, holding a candle in her hands", "Vigil at Midnight" },
                    { 47, null, 4, "This artwork shows an unknown marquise dressed in an exquisite 18th-century red dress adorned with flower patterns.", "The Marquise in a Scarlet Dress" },
                    { 48, null, 1, "This artwork depicts a beautiful woman with brown hair, wearing an 18th-century dress, situated within a gothic cloister illuminated by candles.", "The Lady of the Candlelit Cloister" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtImageId",
                schema: "EnigmaticEtherealElegiesArt",
                table: "Artworks",
                column: "ArtImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtistId",
                schema: "EnigmaticEtherealElegiesArt",
                table: "Artworks",
                column: "ArtistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artworks",
                schema: "EnigmaticEtherealElegiesArt");

            migrationBuilder.DropTable(
                name: "ArtImages",
                schema: "EnigmaticEtherealElegiesArt");

            migrationBuilder.DropTable(
                name: "Artists",
                schema: "EnigmaticEtherealElegiesArt");
        }
    }
}
