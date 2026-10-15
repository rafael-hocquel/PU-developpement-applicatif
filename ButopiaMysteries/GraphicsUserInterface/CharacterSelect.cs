using ButopiaMysteries.Logic;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ButopiaMysteries.GraphicsUserInterface
{
    /// <summary>
    /// A window tha allows to select/create mysteries/characters.
    /// </summary>
    public partial class CharacterSelect : Form
    {
        // Drop areas for characters to launch trials
        /// <summary>
        /// The area of the open trial
        /// </summary>
        private Rectangle openTrialArea;
        /// <summary>
        /// The area of the closed trial
        /// </summary>
        private Rectangle closedTrialArea;
        /// <summary>
        /// The area of the training room
        /// </summary>
        private Rectangle trainingArea;
        /// <summary>
        /// True if a character is being dragged false if not
        /// </summary>
        private bool dragging = false;
        /// <summary>
        /// The character being dragged
        /// </summary>
        private CharacterView draggedCharacter;



        /// <summary>
        /// Roster containing the characters information
        /// </summary>
        private Roster Roster { get; init; } = new();
        /// <summary>
        /// The point where the next character will be located
        /// </summary>
        private Point referencePoint = Point.Empty;
        /// <summary>
        /// The showed characters
        /// </summary>
        private readonly List<CharacterView> views = [];
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public CharacterSelect()
        {
            InitializeComponent();
            BackColor = ViewSettings.BackgroundColor;

            // Very first try: create a character, put it in the roster, associate it to the button
            int characters = Math.Min(ViewSettings.DefaultCharacterNumber, MaxCharactersOnScreen());
            if (characters != ViewSettings.DefaultCharacterNumber)
            {
                MessageBox.Show("Avertissement", "Le maximum de personnages est de " + MaxCharactersOnScreen() + ", certains des personnages par defaut ne seront pas crées", MessageBoxButtons.OK);
            }

            for (int i = 0; i < characters; i++)
            {
                CreateRandom(true);
            }

            // Drop Areas 
            openTrialArea = new Rectangle(600, 50, 180, 100);
            closedTrialArea = new Rectangle(600, 170, 180, 100);
            trainingArea = new Rectangle(600, 290, 180, 100);

            // Fill comboBox data - Syntaxe pour remplir les comboBox basés sur une enumeration trouvée sur StackOverflow (https://stackoverflow.com/questions/49712523/using-enums-in-combobox)
            skillComboBox.DataSource = Enum.GetValues(typeof(Skill));
            difficultyComboBox.DataSource = Enum.GetValues(typeof(Difficulty));
        }

        /// <summary>
        /// Calculates the maximum ammount of characters which can fit on the sceen 
        /// </summary>
        /// <returns>The maximum ammount</returns>
        public int MaxCharactersOnScreen()
        {
            // Horizontal and vertical space taken by adding a new pawn (margin + pawn size)
            int stepHorizontal = ViewSettings.DefaultPawnSide + ViewSettings.DefaultPawnFrame.Width;
            int stepVertical = ViewSettings.DefaultPawnSide + ViewSettings.DefaultPawnFrame.Height;

            // Max rows and cols without overflowing on the buttons
            int maxCols = createButton.Left / stepHorizontal;
            int maxRows = quitButton.Top / stepVertical;

            return maxCols * maxRows;
        }

        /// <summary>
        /// Draws all the characters and drop zones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterSelect_Paint(object sender, PaintEventArgs e)
        {
            foreach (CharacterView viewCharacter in views)
            {
                viewCharacter.Draw(e.Graphics);
            }


            // Draw drop zones
            e.Graphics.DrawRectangle(Pens.Black, openTrialArea);
            e.Graphics.DrawString("Auto-Eval", Font, Brushes.Black, openTrialArea.Location);

            e.Graphics.DrawRectangle(Pens.Black, closedTrialArea);
            e.Graphics.DrawString("Examen", Font, Brushes.Black, closedTrialArea.Location);

            e.Graphics.DrawRectangle(Pens.Black, trainingArea);
            e.Graphics.DrawString("Entrainement", Font, Brushes.Black, trainingArea.Location);
        }

        /// <summary>
        /// Crates the view of each character
        /// </summary>
        private void CreateCharacterViews()
        {
            views.Clear();
            // Top Left Corner
            referencePoint = Point.Empty;
            foreach (string name in Roster.Sheets.Keys)
            {
                AddOneNewCharacterView(Roster.Sheets[name]);
            }
        }
        /// <summary>
        /// Draws a character
        /// </summary>
        /// <param name="sheet">The character to draw</param>
        private void AddOneNewCharacterView(MysterySheet sheet)
        {
            int x = referencePoint.X;
            int y = referencePoint.Y + ViewSettings.DefaultPawnSide;

            if (y + ViewSettings.DefaultPawnFrame.Height > quitButton.Top)
            {
                x += ViewSettings.DefaultPawnSide + ViewSettings.DefaultPawnFrame.Width;
                y = ViewSettings.DefaultPawnSide;
            }

            views.Add(new CharacterView(sheet, new Point(x, y)));

            referencePoint = new Point(x, y + ViewSettings.DefaultPawnFrame.Height);
            createButton.Enabled = views.Count < MaxCharactersOnScreen();
            Refresh();
        }
        /// <summary>
        /// Opens the dialog to create a new character and creates it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            NewCharacterDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Rules rules = dialog.RandomGeneration ? Rules.None : Rules.Fixed;
                if (dialog.CharacterName.Count() == 0)
                {
                    CreateRandom();
                }
                else
                {
                    CreateRandomWithName(dialog.CharacterName, dialog.Plan, dialog.Sphere, rules);
                }
            }
        }

        /// <summary>
        /// Creates a random character
        /// </summary>
        /// <param name="retryOnExisting">If true it will loop as many times as necessary to have the desired amount of characters</param>
        private void CreateRandom(bool retryOnExisting = false)
        {
            string name = Names.RandomName;
            if (retryOnExisting && Roster.Sheets.ContainsKey(name))
            {
                int maxRetry = 35;
                int i = 0;
                while (Roster.Sheets.ContainsKey(name) && i < maxRetry)
                {
                    name = Names.RandomName;
                    i++;
                }
            }
            Random random = new Random();
            Plan[] plans = Enum.GetValues<Plan>();
            Sphere[] sphere = Enum.GetValues<Sphere>();

            Plan finalPlan = (Plan)plans.GetValue(random.Next(plans.Length));
            Sphere finalSphere = (Sphere)sphere.GetValue(random.Next(sphere.Length));
            CreateRandomWithName(name, finalPlan, finalSphere, Rules.None);
        }

        /// <summary>
        /// Creates a new character
        /// </summary>
        /// <param name="name">Character name</param>
        /// <param name="plan">Plan of the charcter</param>
        /// <param name="sphere">Sphere of the character</param>
        /// <param name="rules">The rules to set the characters statistics</param>
        private void CreateRandomWithName(string name, Plan plan, Sphere sphere, Rules rules = Rules.None)
        {
            if (Roster.Sheets.ContainsKey(name))
            {
                MessageBox.Show("Erreur : " + name + " déjà présent !");
                return;
            }
            MysterySheet sheet = new(name);
            sheet.Plan = plan;
            sheet.Sphere = sphere;
            sheet.RandomGeneration(rules);
            Roster.Sheets.Add(sheet.Name, sheet);
            AddOneNewCharacterView(sheet);
        }

        /// <summary>
        /// Closes the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Run the code for moving a character if the left mouse is pressed, removes a character if the right mouse button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterSelect_MouseDown(object sender, MouseEventArgs e)
        {   

            foreach (CharacterView viewCharacter in views)
            {
                if (viewCharacter.Contains(e.Location))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        dragging = true;
                        draggedCharacter = viewCharacter;
                        return;
                    }
                    else
                    {
                        // Confirmation dialog
                        DialogResult diag = MessageBox.Show("Etes-vous sur de vouloir supprimer " + viewCharacter.Sheet.Name + " ?", "Cette action est irréversible", MessageBoxButtons.YesNo);
                        if (diag == DialogResult.Yes)
                        {
                            Roster.Sheets.Remove(viewCharacter.Sheet.Name);
                        }

                    }
                }
            }
            CreateCharacterViews();
            Refresh();
        }

        /// <summary>
        /// Shows the sheet of a character on double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterSelect_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (CharacterView viewCharacter in views)
                {
                    if (viewCharacter.Contains(e.Location))
                    {

                        new SheetView(Roster.Sheets[viewCharacter.Sheet.Name]).ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// If a character if being moved, set it's position to the mouse position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterSelect_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging && draggedCharacter != null)
            {
                draggedCharacter.location = e.Location;
                Refresh();
            }
        }

        /// <summary>
        /// Launch a trial if a character is dragged in it's area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterSelect_MouseUp(object sender, MouseEventArgs e)
        {
            if (!dragging || draggedCharacter == null)
            {
                return;
            }
            dragging = false;

            bool isInOpenTrialArea = openTrialArea.Contains(e.Location);
            bool isInClosedTrialArea = closedTrialArea.Contains(e.Location);
            bool isInTrainingArea = trainingArea.Contains(e.Location);

            if (isInTrainingArea)
            {
                TrainingView trainingView = new(draggedCharacter.Sheet);
                trainingView.ShowDialog();

                CreateCharacterViews();
                Refresh();
                draggedCharacter = null;
                return;
            }

            if (isInOpenTrialArea || isInClosedTrialArea)
            {
                // Syntaxe trouvée sur stack overflow qui permet de vérifier que le contemu de la combobox != null et de créer une variable "skill" si ce n'est pas null
                if (skillComboBox.SelectedItem is not Skill skill || skill == Skill.None)
                {
                    MessageBox.Show("Selectionner un skill");
                    CreateCharacterViews();
                    Refresh();
                    draggedCharacter = null;
                    return;
                }

                if (isInOpenTrialArea)
                {
                    TrialView trialView = new(draggedCharacter.Sheet, skill);
                    trialView.ShowDialog();
                }
                else
                {
                    if (difficultyComboBox.SelectedItem is not Difficulty difficulty)
                    {
                        MessageBox.Show("Selectionner une difficulté");
                        CreateCharacterViews();
                        Refresh();
                        draggedCharacter = null;
                        return;
                    }

                    TrialView trialView = new(draggedCharacter.Sheet, skill, difficulty);
                    trialView.ShowDialog();
                }
            }

            CreateCharacterViews();
            Refresh();
            draggedCharacter = null;
        }
    }
}