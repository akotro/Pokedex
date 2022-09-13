using Newtonsoft.Json;
using PokeAPI.Models;
using System.Diagnostics;

namespace Pokedex
{
    public partial class Pokedex : Form
    {
        internal PokeApiHandler ApiHandler { get; set; }
        internal RestSharpHandler RestSharpHandler { get; set; }
        internal List<string> NameList { get; set; }

        public Pokedex()
        {
            InitializeComponent();

            var apiProcess = Process.Start(@"C:\Users\akotr\programming\ConnectLine\PokeAPI\PokeAPI\bin\Debug\net6.0\PokeApi.exe");

            ApiHandler = new PokeApiHandler();
            RestSharpHandler = new RestSharpHandler("https://localhost:5001/api/pokemon/");

            NameList = GetLocalPokemon();

            textBoxSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(NameList.ToArray());
            textBoxSearch.AutoCompleteCustomSource = autoComplete;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxSearch.Text))
                UpdatePokemon(textBoxSearch.Text.ToLower());
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxSearch.Text) && e.KeyValue == (char)Keys.Return)
            {
                UpdatePokemon(textBoxSearch.Text.ToLower());
            }

        }

        private List<string> GetLocalPokemon()
        {
            var nameList = new List<string>();

            try
            {
                var response = RestSharpHandler.RequestRestSharp("", "", RestSharp.Method.Get);

                var result = new List<Pokemon>();
                if (!string.IsNullOrWhiteSpace(response.Content))
                    result = JsonConvert.DeserializeObject<List<Pokemon>>(response.Content);

                var pokeList = new List<string>();
                foreach (var pokemon in result)
                {
                    pokeList.Add(pokemon.ToString());
                    nameList.Add(pokemon.Name);
                }

                listBoxPokemon.DataSource = pokeList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return nameList;
        }

        private void UpdatePokemon(string name)
        {
            try
            {
                buttonSearch.Enabled = false;

                var pokemon = ApiHandler.GetPokemon(name);

                if (pokemon != null)
                {
                    labelName.Text = Capitalize(pokemon.Name);
                    pictureBoxSprite.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxSprite.ImageLocation = pokemon.Sprites.Other.OfficialArtwork.FrontDefault;

                    string types = string.Empty;
                    foreach (var type in pokemon.Types)
                    {
                        if (type.Slot == 1)
                        {
                            types += Capitalize(type.TypeName.Name);
                        }
                        else
                        {
                            types += ", " + Capitalize(type.TypeName.Name);
                        }
                    }
                    labelTypeName.Text = types;
                }

                buttonSearch.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string Capitalize(string text)
        {
            return text[..1].ToUpper() + text[1..];
        }

        private void listBoxPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = listBoxPokemon.SelectedIndex;

            if (NameList != null)
            {
                string name = NameList[id];

                UpdatePokemon(name);
            }
        }
    }
}
