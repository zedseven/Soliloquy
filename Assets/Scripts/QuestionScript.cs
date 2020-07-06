using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

using UIText = UnityEngine.UI.Text;
using UIImage = UnityEngine.UI.Image;

public class QuestionScript : MonoBehaviour
{
	public Question[] questions = new Question[0];
	
	public string[] subscripts = new string[10] { "₀", "₁", "₂", "₃", "₄", "₅", "₆", "₇", "₈", "₉" };
	public string[] subscriptAlphas = new string[26] { "ᵃ", "ᵇ", "ᶜ", "ᵈ", "ᵉ", "ᶠ", "ᵍ", "ʰ", "ᵢ", "ʲ", "ᵏ", "ˡ", "ᵐ", "ⁿ", "ᵒ", "ₚ", " ", "ʳ", "ˢ", "ᵗ", "ᵘ", "ᵛ", "ʷ", "ˣ", "ʸ", "ᶻ" };
	public string[] subscriptSigns = new string[5] { "₊", "₋", "₌", "₍", "₎" };
	public string[] superscripts = new string[10] { "⁰", "¹", "²", "³", "⁴", "⁵", "⁶", "⁷", "⁸", "⁹" };
	public string[] superscriptSigns = new string[5] { "⁺", "⁻", "⁼", "⁽", "⁾" };
	public string[] romanNumerals = new string[10] { "-", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
	public string[] molecularPrefixes = new string[11] { "Anti", "Mono", "Di", "Tri", "Tetra", "Penta", "Hexa", "Hepta", "Octa", "Nona", "Deca" };
	public bool[] molecularPrefixesVowelRemove = new bool[11] { true, true, false, false, true, true, false, true, false, true, false };
	
	public char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
	public Element[] elements = new Element[118] //http://www.lenntech.com/periodic/number/atomic-number.htm : http://www.nelson.com/scienceperspectives/10/uniflip-closing/index.html
	{
		//a, e, t, m, l, n, h, g, i, d
		new Element(1, "Hydrogen", "Hydr", "H", 'n', new int[2] { 1, -1 }), 
		new Element(2, "Helium", "Hel", "He", 'g', new int[1] { 0 }), 
		new Element(3, "Lithium", "Lith", "Li", 'a', new int[1] { 1 }), 
		new Element(4, "Beryllium", "Beryll", "Be", 'e', new int[1] { 2 }), 
		new Element(5, "Boron", "Bor", "B", 'l', new int[1] { 0 }), 
		new Element(6, "Carbon", "Carb", "C", 'n', new int[1] { 0 }), 
		new Element(7, "Nitrogen", "Nitr", "N", 'n', new int[1] { -3 }), 
		new Element(8, "Oxygen", "Ox", "O", 'n', new int[1] { -2 }), 
		new Element(9, "Fluorine", "Fluor", "F", 'h', new int[1] { -1 }), 
		new Element(10, "Neon", "Neon", "Ne", 'g', new int[1] { 0 }), 
		new Element(11, "Sodium", "Sod", "Na", 'a', new int[1] { 1 }), 
		new Element(12, "Magnesium", "Magnes", "Mg", 'e', new int[1] { 2 }), 
		new Element(13, "Aluminum", "Alumin", "Al", 'm', new int[1] { 3 }), 
		new Element(14, "Silicon", "Silic", "Si", 'l', new int[1] { 0 }), 
		new Element(15, "Phosphorus", "Phosph", "P", 'n', new int[1] { -3 }), 
		new Element(16, "Sulfur", "Sulf", "S", 'n', new int[1] { -2 }), 
		new Element(17, "Chlorine", "Chlor", "Cl", 'h', new int[1] { -1 }), 
		new Element(18, "Argon", "Argon", "Ar", 'g', new int[1] { 0 }), 
		new Element(19, "Potassium", "Potass", "K", 'a', new int[1] { 1 }), 
		new Element(20, "Calcium", "Calc", "Ca", 'e', new int[1] { 2 }), 
		new Element(21, "Scandium", "Scand", "Sc", 't', new int[1] { 3 }), 
		new Element(22, "Titanium", "Titan", "Ti", 't', new int[2] { 4, 3 }), 
		new Element(23, "Vanadium", "Vanad", "V", 't', new int[2] { 5, 4 }), 
		new Element(24, "Chromium", "Chrom", "Cr", 't', new int[2] { 3, 2 }), 
		new Element(25, "Manganese", "Mangan", "Mn", 't', new int[2] { 2, 4 }), 
		new Element(26, "Iron", "Iron", "Fe", 't', new int[2] { 3, 2 }), 
		new Element(27, "Cobalt", "Cob", "Co", 't', new int[2] { 2, 3 }), 
		new Element(28, "Nickel", "Nick", "Ni", 't', new int[2] { 2, 3 }), 
		new Element(29, "Copper", "Copp", "Cu", 't', new int[2] { 2, 1 }), 
		new Element(30, "Zinc", "Zinc", "Zn", 't', new int[1] { 2 }), 
		new Element(31, "Gallium", "Gall", "Ga", 'm', new int[1] { 3 }), 
		new Element(32, "Germanium", "German", "Ge", 'l', new int[1] { 4 }), 
		new Element(33, "Arsenic", "Arsen", "As", 'l', new int[1] { -3 }), 
		new Element(34, "Selenium", "Selen", "Se", 'n', new int[1] { -2 }), 
		new Element(35, "Bromine", "Brom", "Br", 'h', new int[1] { -1 }), 
		new Element(36, "Krypton", "Krypton", "Kr", 'g', new int[1] { 0 }), 
		new Element(37, "Rubidium", "Rubid", "Rb", 'a', new int[1] { 1 }), 
		new Element(38, "Strontium", "Stront", "Sr", 'e', new int[1] { 2 }), 
		new Element(39, "Yttrium", "Yttr", "Y", 't', new int[1] { 3 }), 
		new Element(40, "Zirconium", "Zirc", "Zr", 't', new int[1] { 4 }), 
		new Element(41, "Niobium", "Niob", "Nb", 't', new int[2] { 5, 3 }), 
		new Element(42, "Molybdenum", "Molybden", "Mo", 't', new int[1] { 6 }), 
		new Element(43, "Technetium", "Technet", "Tc", 't', new int[1] { 7 }), 
		new Element(44, "Ruthenium", "Ruthen", "Ru", 't', new int[2] { 3, 4 }), 
		new Element(45, "Rhodium", "Rhod", "Rh", 't', new int[1] { 3 }), 
		new Element(46, "Palladium", "Pallad", "Pd", 't', new int[2] { 2, 3 }), 
		new Element(47, "Silver", "Silv", "Ag", 't', new int[1] { 1 }), 
		new Element(48, "Cadmium", "Cadm", "Cd", 't', new int[1] { 2 }), 
		new Element(49, "Indium", "Ind", "In", 'm', new int[1] { 3 }), 
		new Element(50, "Tin", "Tin", "Sn", 'm', new int[2] { 4, 2 }), 
		new Element(51, "Antimony", "Antim", "Sb", 'l', new int[2] { 3, 5 }), 
		new Element(52, "Tellurium", "Tellur", "Te", 'l', new int[1] { -2 }), 
		new Element(53, "Iodine", "Iod", "I", 'h', new int[1] { -1 }), 
		new Element(54, "Xenon", "Xen", "Xe", 'g', new int[1] { 0 }), 
		new Element(55, "Cesium", "Ces", "Cs", 'a', new int[1] { 1 }), 
		new Element(56, "Barium", "Bar", "Ba", 'e', new int[1] { 2 }), 
		new Element(57, "Lanthanum", "Lanthan", "La", 'i', new int[2] { 3, 2 }), 
		new Element(58, "Cerium", "Cer", "Ce", 'i', new int[1] { 3 }), 
		new Element(59, "Praseodymium", "Praseodym", "Pr", 'i', new int[1] { 3 }), 
		new Element(60, "Neodymium", "Neodym", "Nd", 'i', new int[1] { 3 }), 
		new Element(61, "Promethium", "Prometh", "Pm", 'i', new int[1] { 3 }), 
		new Element(62, "Samarium", "Samar", "Sm", 'i', new int[2] { 3, 2 }), 
		new Element(63, "Europium", "Europ", "Eu", 'i', new int[2] { 3, 2 }), 
		new Element(64, "Gadolinium", "Gadolin", "Gd", 'i', new int[1] { 3 }), 
		new Element(65, "Terbium", "Terb", "Tb", 'i', new int[1] { 3 }), 
		new Element(66, "Dysprosium", "Dyspros", "Dy", 'i', new int[1] { 3 }), 
		new Element(67, "Holmium", "Holm", "Ho", 'i', new int[1] { 3 }), 
		new Element(68, "Erbium", "Erb", "Er", 'i', new int[1] { 3 }), 
		new Element(69, "Thulium", "Thul", "Tm", 'i', new int[1] { 3 }), 
		new Element(70, "Ytterbium", "Ytterb", "Yb", 'i', new int[2] { 3, 2 }), 
		new Element(71, "Lutetium", "Lutet", "Lu", 'i', new int[1] { 2 }), 
		new Element(72, "Hafnium", "Hafn", "Hf", 't', new int[1] { 4 }), 
		new Element(73, "Tantalum", "Tantal", "Ta", 't', new int[1] { 5 }), 
		new Element(74, "Tungsten", "Tungst", "W", 't', new int[1] { 6 }), 
		new Element(75, "Rhenium", "Rhen", "Re", 't', new int[1] { 7 }), 
		new Element(76, "Osmium", "Osm", "Os", 't', new int[1] { 4 }), 
		new Element(77, "Iridium", "Irid", "Ir", 't', new int[1] { 4 }), 
		new Element(78, "Platinum", "Platin", "Pt", 't', new int[2] { 4, 2 }), 
		new Element(79, "Gold", "Gold", "Au", 't', new int[2] { 3, 1 }), 
		new Element(80, "Mercury", "Mercur", "Hg", 't', new int[2] { 2, 1 }), 
		new Element(81, "Thallium", "Thall", "Tl", 'm', new int[2] { 1, 3 }), 
		new Element(82, "Lead", "Lead", "Pb", 'm', new int[2] { 2, 4 }), 
		new Element(83, "Bismuth", "Bism", "Bi", 'm', new int[2] { 3, 5 }), 
		new Element(84, "Polonium", "Polon", "Po", 'l', new int[2] { 2, 4 }), 
		new Element(85, "Astatine", "Astat", "At", 'h', new int[1] { -1 }), 
		new Element(86, "Radon", "Radon", "Rn", 'g', new int[1] { 0 }), 
		new Element(87, "Francium", "Franc", "Fr", 'a', new int[1] { 1 }), 
		new Element(88, "Radium", "Rad", "Ra", 'e', new int[1] { 2 }), 
		new Element(89, "Actinium", "Actin", "Ac", 'd', new int[2] { 3, 2 }), 
		new Element(90, "Thorium", "Thor", "Th", 'd', new int[1] { 4 }), 
		new Element(91, "Protactinium", "Protactin", "Pa", 'd', new int[2] { 5, 4 }), 
		new Element(92, "Uranium", "Uran", "U", 'd', new int[2] { 6, 4 }), 
		new Element(93, "Neptunium", "Neptun", "Np", 'd', new int[1] { 5 }), 
		new Element(94, "Plutonium", "Pluton", "Pu", 'd', new int[2] { 4, 6 }), 
		new Element(95, "Americium", "Americ", "Am", 'd', new int[2] { 3, 4 }), 
		new Element(96, "Curium", "Cur", "Cm", 'd', new int[1] { 3 }), 
		new Element(97, "Berkelium", "Berkel", "Bk", 'd', new int[2] { 3, 4 }), 
		new Element(98, "Californium", "Californ", "Cf", 'd', new int[1] { 3 }), 
		new Element(99, "Einsteinium", "Einstein", "Es", 'd', new int[1] { 3 }), 
		new Element(100, "Fermium", "Ferm", "Fm", 'd', new int[1] { 3 }), 
		new Element(101, "Mendelevium", "Mendelev", "Md", 'd', new int[2] { 2, 3 }), 
		new Element(102, "Nobelium", "Nobel", "No", 'd', new int[2] { 2, 3 }), 
		new Element(103, "Lawrencium", "Lawrenc", "Lr", 'd', new int[1] { 3 }), 
		new Element(104, "Rutherfordium", "Rutherford", "Rf", 't', new int[0] { }), 
		new Element(105, "Dubnium", "Dubn", "Db", 't', new int[0] { }), 
		new Element(106, "Seaborgium", "Seaborg", "Sg", 't', new int[0] { }), 
		new Element(107, "Bohrium", "Bohr", "Bh", 't', new int[0] { }), 
		new Element(108, "Hassium", "Hass", "Hs", 't', new int[0] { }), 
		new Element(109, "Meitnerium", "Meitner", "Mt", 't', new int[0] { }), 
		new Element(110, "Darmstadtium", "Darmstadt", "Ds", 't', new int[0] { }), 
		new Element(111, "Roentgenium", "Roentgen", "Rg", 't', new int[0] { }), 
		new Element(112, "Copernicium", "Copernic", "Cn", 't', new int[0] { }), 
		new Element(113, "Ununtrium", "Ununtr", "Uut", 'm', new int[0] { }), 
		new Element(114, "Flerovium", "Flerov", "Fl", 'm', new int[0] { }), 
		new Element(115, "Ununpentium", "Ununpent", "Uup", 'm', new int[0] { }), 
		new Element(116, "Livermorium", "Livermor", "Lv", 'm', new int[0] { }), 
		new Element(117, "Ununseptium", "Ununsept", "Uus", 'h', new int[0] { }), 
		new Element(118, "Ununoctium", "Ununoct", "Uuo", 'g', new int[0] { })
	};
	public PolyComp[] polyatomicCompounds = new PolyComp[22]
	{
		new PolyComp("Ammonium", new int[2] { 6, 0 }, new int[2] { 1, 4 }, 1), 
		new PolyComp("Nitrite", new int[2] { 6, 7 }, new int[2] { 1, 2 }, -1), 
		new PolyComp("Nitrate", new int[2] { 6, 7 }, new int[2] { 1, 3 }, -1), 
		new PolyComp("Sulfite", new int[2] { 15, 7 }, new int[2] { 1, 3 }, -2), 
		new PolyComp("Sulfate", new int[2] { 15, 7 }, new int[2] { 1, 4 }, -2), 
		new PolyComp("Hydrogen-Sulfate", new int[3] { 0, 15, 7 }, new int[3] { 1, 1, 4 }, -1), 
		new PolyComp("Hydroxide", new int[2] { 7, 0 }, new int[2] { 1, 1 }, -1), 
		new PolyComp("Cyanide", new int[2] { 5, 6 }, new int[2] { 1, 1 }, -1), 
		new PolyComp("Phosphate", new int[2] { 14, 7 }, new int[2] { 1, 4 }, -3), 
		new PolyComp("Hydrogen-Phosphate", new int[3] { 0, 14, 7 }, new int[3] { 1, 1, 4 }, -2), 
		new PolyComp("DiHydrogen-Phosphate", new int[3] { 0, 14, 7 }, new int[3] { 2, 1, 4 }, -1), 
		new PolyComp("Carbonate", new int[2] { 5, 7 }, new int[2] { 1, 3 }, -2), 
		new PolyComp("Hydrogen-Carbonate", new int[3] { 0, 5, 7 }, new int[3] { 1, 1, 3 }, -1), 
		new PolyComp("Hypochlorite", new int[2] { 16, 7 }, new int[2] { 1, 1 }, -1), 
		new PolyComp("Chlorite", new int[2] { 16, 7 }, new int[2] { 1, 2 }, -1), 
		new PolyComp("Chlorate", new int[2] { 16, 7 }, new int[2] { 1, 3 }, -1), 
		new PolyComp("Perchlorate", new int[2] { 16, 7 }, new int[2] { 1, 4 }, -1), 
		new PolyComp("Acetate", new int[3] { 5, 0, 7 }, new int[3] { 2, 3, 2 }, -1), 
		new PolyComp("Permanganate", new int[2] { 24, 7 }, new int[2] { 1, 4 }, -1), 
		new PolyComp("Dichromate", new int[2] { 23, 7 }, new int[2] { 2, 7 }, -2), 
		new PolyComp("Chromate", new int[2] { 23, 7 }, new int[2] { 1, 4 }, -2), 
		new PolyComp("Peroxide", new int[1] { 7 }, new int[1] { 2 }, -2)
	};
	public Diagram[] questionDiagrams = new Diagram[30]
	{
		new Diagram(-1, false, null, DiagramType.Empty), 
		new Diagram(0, false, null, DiagramType.BohrRutherford), 
		new Diagram(1, true, null, DiagramType.BohrRutherford), 
		new Diagram(2, false, null, DiagramType.BohrRutherford), 
		new Diagram(3, false, null, DiagramType.BohrRutherford), 
		new Diagram(4, false, null, DiagramType.BohrRutherford), 
		new Diagram(5, false, null, DiagramType.BohrRutherford), 
		new Diagram(6, false, null, DiagramType.BohrRutherford), 
		new Diagram(7, false, null, DiagramType.BohrRutherford), 
		new Diagram(8, false, null, DiagramType.BohrRutherford), 
		new Diagram(9, true, null, DiagramType.BohrRutherford), 
		new Diagram(-1, false, null, DiagramType.SafetySymbol), 
		new Diagram(-1, false, null, DiagramType.SafetySymbol), 
		new Diagram(-1, false, null, DiagramType.SafetySymbol), 
		new Diagram(-1, false, null, DiagramType.SafetySymbol), 
		new Diagram(-1, false, null, DiagramType.SafetySymbol), 
		new Diagram(-1, false, null, DiagramType.SafetySymbol), 
		new Diagram(-1, false, null, DiagramType.SafetySymbol), 
		new Diagram(-1, false, null, DiagramType.SafetySymbol), 
		new Diagram(-1, false, null, DiagramType.SafetySymbol), 
		new Diagram(0, false, null, DiagramType.LewisDot), 
		new Diagram(1, true, null, DiagramType.LewisDot), 
		new Diagram(2, false, null, DiagramType.LewisDot), 
		new Diagram(3, false, null, DiagramType.LewisDot), 
		new Diagram(4, false, null, DiagramType.LewisDot), 
		new Diagram(5, false, null, DiagramType.LewisDot), 
		new Diagram(6, false, null, DiagramType.LewisDot), 
		new Diagram(7, false, null, DiagramType.LewisDot), 
		new Diagram(8, false, null, DiagramType.LewisDot), 
		new Diagram(9, true, null, DiagramType.LewisDot)
	};
	
	public char[] metals = new char[4] { 'a', 'e', 't', 'm' };
	public char[] nonmetals = new char[2] { 'n', 'h' };
	
	public int[] usedElements = new int[0];
	public int[] usedPolies = new int[0];
	private ParseVar[] pVars = new ParseVar[0];
	
	private int cQuestion = -1;
	private int cIQuestion = -1;
	private int iQuestionIndex = -1;
	
	public GameObject player = null;
	
	public enum QuestionType
	{
		Text = 0,
		Image = 1
	}
	
	[System.Serializable]
	public class Question
	{
		public string name = "";
		public string officialName = "";
		public int likelihood = 1;
		public QuestionType questionType = QuestionType.Text;
		public IndivQuestion[] individualQuestions = new IndivQuestion[0];
		
		//public bool done = false;
	}
	
	[System.Serializable]
	public class IndivQuestion
	{
		public int qID = 0;
		public int qLikelihood = 1;
		//public int qDifficulty = 1;
		public string qParams = "";
		public string additionalQParam = "";
		public Answer[] answers = new Answer[0];
	}
	
	[System.Serializable]
	public class Answer
	{
		public bool correct = false;
		public string[] aParamsList = new string[1]; //randomly picks between them as possible answers. only 1 is okay.
	}
	
	[System.Serializable]
	public class Element
	{
		public string name = "";
		public string baseName = "";
		public int atomicNumber = -1;
		public string symbol = "";
		public int[] commonCharges = new int[0];
		public char type = 'u';
		
		public Element(int nAtomicNumber, string nName, string nBaseName, string nSymbol, char nType, int[] nCommonCharges)
		{
			atomicNumber = nAtomicNumber;
			name = nName;
			baseName = nBaseName;
			symbol = nSymbol;
			type = nType;
			commonCharges = nCommonCharges;
		}
	}
	[System.Serializable]
	public class PolyComp
	{
		public string name = "";
		public int[] symbols = new int[0]; //contains singular elements' elements[] index
		public int[] quantities = new int[0];
		public int charge = 0;
		
		public PolyComp(string nName, int[] nSymbols, int[] nQuantities, int nCharge)
		{
			name = nName;
			symbols = nSymbols;
			quantities = nQuantities;
			charge = nCharge;
		}
	}
	
	public enum DiagramType
	{
		Empty = 0, 
		BohrRutherford = 1, 
		LewisDot = 2, 
		SafetySymbol = 3
	}
	
	[System.Serializable]
	public class Diagram
	{
		public int element = -1;
		public bool stable = false;
		public Sprite image = null;
		public DiagramType diagramType = DiagramType.BohrRutherford;
		
		public Diagram(int nElement, bool nStable, Sprite nImage, DiagramType nDiagramType)
		{
			element = nElement;
			stable = nStable;
			image = nImage;
			diagramType = nDiagramType;
		}
	}
	
	[System.Serializable]
	public class ParseVar
	{
		public string varName = "";
		public string type = "";
		public string value = "";
		
		public ParseVar(string nVarName, string nType, string nValue)
		{
			varName = nVarName;
			type = nType;
			value = nValue;
		}
	}
	
	//UI information & variables
	[System.Serializable]
	public class UIInfo
	{
		public GameObject splashscreen = null;
		public GameObject background = null;
		public GameObject qType = null;
		public GameObject question = null;
		public GameObject imageQuestionSupplement = null;
		public GameObject answersHeader = null;
		public GameObject textA1 = null;
		public GameObject textA2 = null;
		public GameObject textA3 = null;
		public GameObject textA4 = null;
		public GameObject imageA1 = null;
		public GameObject imageA2 = null;
		public GameObject imageA3 = null;
		public GameObject imageA4 = null;
		public GameObject score = null;
		public GameObject finalScore = null;
		public GameObject playAgain = null;
		public GameObject backMenu = null;
		public GameObject menuTitle = null;
		public GameObject	play = null;
		public GameObject	credits = null;
		
		public UIInfo(){} //instantiation function
	}
	public UIInfo uiInfo = new UIInfo();
	
	void Start()
	{
		//store the original index of every answer - POTENTIALLY OBSOLETE.
		/*for(int q = 0; q < questions.Length; q++)
		{
			for(int qI = 0; qI < questions[q].individualQuestions.Length; qI++)
			{
				for(int a = 0; a < questions[q].individualQuestions[qI].answers.Length; a++)
				{
					questions[q].individualQuestions[qI].answers[a].origIndex = a;
				}
			}
		}
		for(int r = 0; r < polyatomicCompounds.Length; r++)
		{
			Debug.LogError(polyatomicCompounds[r].name.Substring(polyatomicCompounds[r].name.Length - 3, 3));
		}*/
		//AskQuestion();
		//ResetQuestion();
		PrepForMenu();
		/*for(int i = 0; i < 100; i++)
		{
			//AskQuestion();
			//Debug.Log("Question: " + GenerateQuestion());
			//Debug.Log(ParseQuestion("Hi there! *i12i1 *i22i2"));
			//Debug.Log(ParseQuestion("Ollo! *I12I1 *I22I2"));
			//Debug.Log(ParseQuestion("Okay! *m12m1 *m22m2"));
			//Debug.Log(ParseQuestion("Lol! *M12M1 *M22M2"));
			//Debug.Log(ParseQuestion("Poly! *p12p1"));
			//Debug.Log(ParseQuestion("Pnaimer! *P12P1"));
			//Debug.Log(ParseQuestion("Vars! *P12P1 ^2P1s"));
			//Debug.Log(ParseQuestion("Variaques! *p12p1 ^2p1n"));
			//Debug.Log(ParseQuestion("Pancakes! *m28pancakes ^8pancakesn"));
			//Debug.Log(ParseQuestion("Watermelones! *m19Watermelo ^9Watermelon *m23car ^3carn"));
			//Debug.Log(ParseQuestion("Waffies! *M27waffles ^7waffless"));
			//Debug.Log(ParseQuestion("Finality! *i12i1 ^2i1n *I22I2 ^2I2s"));
			//Debug.Log(ParseQuestion("*I12I1 *I22I2 SEP ^2I1S^2I2O ^2I2S^2I1O"));
			//Debug.Log(ParseQuestion("*I12I1 *I22I2 SEP ^2I1S^2I1O ^2I2S^2I2O"));
			//Debug.Log(ParseQuestion("*p11t *p21q *q11f"));
			//Debug.Log(ParseQuestion("$p11t^1ts | $p21q^1qs | $q11f^1fs"));
			//Debug.Log(ParseQuestion("$I12I1$P22P2^2I1S^2P2O ^2P2S^2I1O"));
		}*/
		//Debug.Log(ParseQuestion("Hi there! *i12i1 *i22i2"));
	}
	
	void Update()
	{
		if(Time.frameCount % 30 == 0)
		{
			System.GC.Collect();
		}
	}
	
	public void AskQuestion()
	{
		int[] pList = new int[questions.Length];
		for(int i = 0; i < questions.Length; i++)
		{
			pList[i] = questions[i].likelihood;
		}
		
		cQuestion = PickFromList(pList); //chosen question
		
		Vector2[] pIList = new Vector2[questions[cQuestion].individualQuestions.Length];
		for(int i = 0; i < questions[cQuestion].individualQuestions.Length; i++)
		{
			pIList[i] = new Vector2(questions[cQuestion].individualQuestions[i].qID, questions[cQuestion].individualQuestions[i].qLikelihood);
		}
		
		cIQuestion = PickFromList(pIList); //chosen individual question
		
		iQuestionIndex = -1;
		for(int i = 0; i < questions[cQuestion].individualQuestions.Length; i++)
		{
			if(questions[cQuestion].individualQuestions[i].qID == cIQuestion)
			{
				iQuestionIndex = i;
				break;
			}
		}
		
		//cQuestion = 3;
		//iQuestionIndex = 0;//Random.Range(0, questions[cQuestion].individualQuestions.Length);
		
		//Debug.Log("Question Type: " + questions[cQuestion].officialName + " : Question ID: " + questions[cQuestion].individualQuestions[iQuestionIndex].qID);
		uiInfo.qType.GetComponent<UIText>().text = questions[cQuestion].officialName;
		//string[] q = ParseQuestion(questions[cQuestion].individualQuestions[iQuestionIndex].qParams).Split(new string[] {" : "}, System.StringSplitOptions.None);
		//uiInfo.question.GetComponent<UIText>().text = q[q.Length - 1];
		uiInfo.question.GetComponent<UIText>().text = ParseQuestion(questions[cQuestion].individualQuestions[iQuestionIndex].qParams).Split(new string[] {" : "}, System.StringSplitOptions.None).Last();
		
		if(questions[cQuestion].questionType == QuestionType.Text)
		{
			uiInfo.imageA1.SetActive(false);
			uiInfo.imageA2.SetActive(false);
			uiInfo.imageA3.SetActive(false);
			uiInfo.imageA4.SetActive(false);
			uiInfo.textA1.SetActive(true);
			uiInfo.textA2.SetActive(true);
			uiInfo.textA3.SetActive(true);
			uiInfo.textA4.SetActive(true);
			Answer[] answers = questions[cQuestion].individualQuestions[iQuestionIndex].answers;
			RandomizeArray(answers); //scramble the answers
			string[] iAnswers = new string[answers.Length];
			for(int i = 0; i < answers.Length; i++)
			{
				iAnswers[i] = answers[i].aParamsList[Random.Range(0, answers[i].aParamsList.Length)];
			}
			
			//question image
			uiInfo.imageQuestionSupplement.SetActive(false);
			//possible answers
			uiInfo.textA1.GetComponent<UIText>().text = "a) " + ParseQuestion(iAnswers[0]).Split(new string[] {" : "}, System.StringSplitOptions.None).Last();
			uiInfo.textA2.GetComponent<UIText>().text = "b) " + ParseQuestion(iAnswers[1]).Split(new string[] {" : "}, System.StringSplitOptions.None).Last();
			uiInfo.textA3.GetComponent<UIText>().text = "c) " + ParseQuestion(iAnswers[2]).Split(new string[] {" : "}, System.StringSplitOptions.None).Last();
			uiInfo.textA4.GetComponent<UIText>().text = "d) " + ParseQuestion(iAnswers[3]).Split(new string[] {" : "}, System.StringSplitOptions.None).Last();
		}
		else if(questions[cQuestion].questionType == QuestionType.Image)
		{
			uiInfo.textA1.SetActive(false);
			uiInfo.textA2.SetActive(false);
			uiInfo.textA3.SetActive(false);
			uiInfo.textA4.SetActive(false);
			uiInfo.imageA1.SetActive(true);
			uiInfo.imageA2.SetActive(true);
			uiInfo.imageA3.SetActive(true);
			uiInfo.imageA4.SetActive(true);
			Answer[] answers = questions[cQuestion].individualQuestions[iQuestionIndex].answers;
			RandomizeArray(answers); //scramble the answers
			string[] iAnswers = new string[answers.Length];
			for(int i = 0; i < answers.Length; i++)
			{
				iAnswers[i] = answers[i].aParamsList[Random.Range(0, answers[i].aParamsList.Length)];
			}
			
			//question image
			uiInfo.imageQuestionSupplement.SetActive(true);
			uiInfo.imageQuestionSupplement.GetComponent<UIImage>().sprite = questionDiagrams[int.Parse(ParseQuestion(questions[cQuestion].individualQuestions[iQuestionIndex].additionalQParam).Split(new string[] {" : "}, System.StringSplitOptions.None).Last())].image;
			//possible answers
			uiInfo.imageA1.GetComponent<UIImage>().sprite = questionDiagrams[int.Parse(ParseQuestion(iAnswers[0]).Split(new string[] {" : "}, System.StringSplitOptions.None).Last())].image;
			uiInfo.imageA2.GetComponent<UIImage>().sprite = questionDiagrams[int.Parse(ParseQuestion(iAnswers[1]).Split(new string[] {" : "}, System.StringSplitOptions.None).Last())].image;
			uiInfo.imageA3.GetComponent<UIImage>().sprite = questionDiagrams[int.Parse(ParseQuestion(iAnswers[2]).Split(new string[] {" : "}, System.StringSplitOptions.None).Last())].image;
			uiInfo.imageA4.GetComponent<UIImage>().sprite = questionDiagrams[int.Parse(ParseQuestion(iAnswers[3]).Split(new string[] {" : "}, System.StringSplitOptions.None).Last())].image;
		}
		else
		{
			Debug.LogError("Something is wrong with me!");
		}
	}
	
	public void PrepForQuestion()
	{
		StaticPaused.paused = true;
		bool menuOn = false;
		bool deadOn = false;
		bool gameOn = false;
		bool questionOn = true;
		//menu stuff
		//uiInfo.menuHeader.SetActive(false);
		uiInfo.splashscreen.SetActive(menuOn);
		uiInfo.menuTitle.SetActive(menuOn);
		uiInfo.play.SetActive(menuOn);
		uiInfo.credits.SetActive(menuOn);
		//dead stuff
		uiInfo.background.SetActive(deadOn);
		uiInfo.finalScore.SetActive(deadOn);
		uiInfo.playAgain.SetActive(deadOn);
		uiInfo.backMenu.SetActive(deadOn);
		//game stuff
		//uiInfo.gameHeader.SetActive(false);
		uiInfo.score.GetComponent<UIText>().color = Color.black;
		//question stuff
		//uiInfo.questionHeader.SetActive(true);
		uiInfo.score.SetActive(questionOn);
		uiInfo.background.SetActive(questionOn);
		uiInfo.qType.SetActive(questionOn);
		uiInfo.question.SetActive(questionOn);
		uiInfo.imageQuestionSupplement.SetActive(questionOn);
		uiInfo.answersHeader.SetActive(questionOn);
		uiInfo.textA1.SetActive(questionOn);
		uiInfo.textA2.SetActive(questionOn);
		uiInfo.textA3.SetActive(questionOn);
		uiInfo.textA4.SetActive(questionOn);
		uiInfo.imageA1.SetActive(questionOn);
		uiInfo.imageA2.SetActive(questionOn);
		uiInfo.imageA3.SetActive(questionOn);
		uiInfo.imageA4.SetActive(questionOn);
	}
	public void PrepForGame()
	{
		ResetQuestion();
		StaticPaused.paused = false;
		bool menuOn = false;
		bool deadOn = false;
		bool gameOn = true;
		bool questionOn = false;
		//menu stuff
		//uiInfo.menuHeader.SetActive(false);
		uiInfo.splashscreen.SetActive(menuOn);
		uiInfo.menuTitle.SetActive(menuOn);
		uiInfo.play.SetActive(menuOn);
		uiInfo.credits.SetActive(menuOn);
		//dead stuff
		uiInfo.background.SetActive(deadOn);
		uiInfo.finalScore.SetActive(deadOn);
		uiInfo.playAgain.SetActive(deadOn);
		uiInfo.backMenu.SetActive(deadOn);
		//game stuff
		//uiInfo.gameHeader.SetActive(false);
		uiInfo.score.SetActive(gameOn);
		uiInfo.score.GetComponent<UIText>().color = Color.white;
		//question stuff
		//uiInfo.questionHeader.SetActive(true);
		uiInfo.background.SetActive(questionOn);
		uiInfo.qType.SetActive(questionOn);
		uiInfo.question.SetActive(questionOn);
		uiInfo.imageQuestionSupplement.SetActive(questionOn);
		uiInfo.answersHeader.SetActive(questionOn);
		uiInfo.textA1.SetActive(questionOn);
		uiInfo.textA2.SetActive(questionOn);
		uiInfo.textA3.SetActive(questionOn);
		uiInfo.textA4.SetActive(questionOn);
		uiInfo.imageA1.SetActive(questionOn);
		uiInfo.imageA2.SetActive(questionOn);
		uiInfo.imageA3.SetActive(questionOn);
		uiInfo.imageA4.SetActive(questionOn);
	}
	public void PrepForStart()
	{
		ResetGame();
		player.SetActive(true);
		StaticPaused.paused = false;
		bool menuOn = false;
		bool deadOn = false;
		bool gameOn = true;
		bool questionOn = false;
		//menu stuff
		//uiInfo.menuHeader.SetActive(false);
		uiInfo.splashscreen.SetActive(menuOn);
		uiInfo.menuTitle.SetActive(menuOn);
		uiInfo.play.SetActive(menuOn);
		uiInfo.credits.SetActive(menuOn);
		//dead stuff
		uiInfo.background.SetActive(deadOn);
		uiInfo.finalScore.SetActive(deadOn);
		uiInfo.playAgain.SetActive(deadOn);
		uiInfo.backMenu.SetActive(deadOn);
		//game stuff
		//uiInfo.gameHeader.SetActive(false);
		uiInfo.score.SetActive(gameOn);
		uiInfo.score.GetComponent<UIText>().color = Color.white;
		//question stuff
		//uiInfo.questionHeader.SetActive(true);
		uiInfo.background.SetActive(questionOn);
		uiInfo.qType.SetActive(questionOn);
		uiInfo.question.SetActive(questionOn);
		uiInfo.imageQuestionSupplement.SetActive(questionOn);
		uiInfo.answersHeader.SetActive(questionOn);
		uiInfo.textA1.SetActive(questionOn);
		uiInfo.textA2.SetActive(questionOn);
		uiInfo.textA3.SetActive(questionOn);
		uiInfo.textA4.SetActive(questionOn);
		uiInfo.imageA1.SetActive(questionOn);
		uiInfo.imageA2.SetActive(questionOn);
		uiInfo.imageA3.SetActive(questionOn);
		uiInfo.imageA4.SetActive(questionOn);
	}
	public void PrepForMenu()
	{
		ResetQuestion();
		player.SetActive(false);
		StaticPaused.paused = true;
		bool menuOn = true;
		bool deadOn = false;
		bool gameOn = false;
		bool questionOn = false;
		//menu stuff
		//uiInfo.menuHeader.SetActive(false);
		uiInfo.background.SetActive(menuOn);
		uiInfo.splashscreen.SetActive(menuOn);
		uiInfo.menuTitle.SetActive(menuOn);
		uiInfo.play.SetActive(menuOn);
		uiInfo.credits.SetActive(menuOn);
		//dead stuff
		uiInfo.finalScore.SetActive(deadOn);
		uiInfo.playAgain.SetActive(deadOn);
		uiInfo.backMenu.SetActive(deadOn);
		//game stuff
		//uiInfo.gameHeader.SetActive(false);
		uiInfo.score.SetActive(gameOn);
		//question stuff
		//uiInfo.questionHeader.SetActive(true);
		uiInfo.qType.SetActive(questionOn);
		uiInfo.question.SetActive(questionOn);
		uiInfo.imageQuestionSupplement.SetActive(questionOn);
		uiInfo.answersHeader.SetActive(questionOn);
		uiInfo.textA1.SetActive(questionOn);
		uiInfo.textA2.SetActive(questionOn);
		uiInfo.textA3.SetActive(questionOn);
		uiInfo.textA4.SetActive(questionOn);
		uiInfo.imageA1.SetActive(questionOn);
		uiInfo.imageA2.SetActive(questionOn);
		uiInfo.imageA3.SetActive(questionOn);
		uiInfo.imageA4.SetActive(questionOn);
	}
	public void PrepForDead()
	{
		ResetQuestion();
		StaticPaused.paused = true;
		uiInfo.finalScore.GetComponent<UIText>().text = "Final Score: " + GetComponent<ScoreController>().score.ToString("F2");
		bool menuOn = false;
		bool deadOn = true;
		bool gameOn = false;
		bool questionOn = false;
		//menu stuff
		//uiInfo.menuHeader.SetActive(false);
		uiInfo.splashscreen.SetActive(menuOn);
		uiInfo.menuTitle.SetActive(menuOn);
		uiInfo.play.SetActive(menuOn);
		uiInfo.credits.SetActive(menuOn);
		//dead stuff
		uiInfo.score.SetActive(deadOn);
		uiInfo.background.SetActive(deadOn);
		uiInfo.finalScore.SetActive(deadOn);
		uiInfo.playAgain.SetActive(deadOn);
		uiInfo.backMenu.SetActive(deadOn);
		//game stuff
		//uiInfo.gameHeader.SetActive(false);
		//question stuff
		//uiInfo.questionHeader.SetActive(true);
		uiInfo.qType.SetActive(questionOn);
		uiInfo.question.SetActive(questionOn);
		uiInfo.imageQuestionSupplement.SetActive(questionOn);
		uiInfo.answersHeader.SetActive(questionOn);
		uiInfo.textA1.SetActive(questionOn);
		uiInfo.textA2.SetActive(questionOn);
		uiInfo.textA3.SetActive(questionOn);
		uiInfo.textA4.SetActive(questionOn);
		uiInfo.imageA1.SetActive(questionOn);
		uiInfo.imageA2.SetActive(questionOn);
		uiInfo.imageA3.SetActive(questionOn);
		uiInfo.imageA4.SetActive(questionOn);
	}
	
	public void ResetQuestion()
	{
		cQuestion = -1;
		cIQuestion = -1;
		iQuestionIndex = -1;
		usedElements = new int[0];
		usedPolies = new int[0];
		pVars = new ParseVar[0];
		
		uiInfo.textA1.GetComponent<UIText>().text = "a1";
		uiInfo.textA2.GetComponent<UIText>().text = "a2";
		uiInfo.textA3.GetComponent<UIText>().text = "a3";
		uiInfo.textA4.GetComponent<UIText>().text = "a4";
		uiInfo.imageA1.GetComponent<UIImage>().sprite = null;
		uiInfo.imageA2.GetComponent<UIImage>().sprite = null;
		uiInfo.imageA3.GetComponent<UIImage>().sprite = null;
		uiInfo.imageA4.GetComponent<UIImage>().sprite = null;
	}
	public void ResetGame()
	{
		ResetQuestion();
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
		for(int i = 0; i < obstacles.Length; i++)
		{
			GetComponent<ObstacleSpawner>().DestroyObstacle(obstacles[i]);//Destroy(obstacles[i]);
		}
		GetComponent<ObstacleSpawner>().SetNSpawnTime(1.0f);
		GetComponent<ScoreController>().score = 0.0f;
		uiInfo.score.GetComponent<UIText>().color = Color.white;
	}
	
	private string GenerateQuestion()
	{
		int randElement1 = Random.Range(0, 118);
		int randQuantity1 = Random.Range(1, 10);
		int randCharge1 = Random.Range(0, 10);
		int randSign1 = Random.Range(0, 2);
		int randElement2 = Random.Range(0, 118);
		int randQuantity2 = Random.Range(1, 10);
		int randCharge2 = Random.Range(0, 10);
		int randSign2 = Random.Range(0, 2);
		
		string newQ = "";
		
		newQ += elements[randElement1].symbol;
		if(randCharge1 != 1)
		{
			newQ += superscriptSigns[randSign1];
			newQ += superscripts[randCharge1];
		}
		if(randQuantity1 > 1)
		{
			newQ += subscripts[randQuantity1];
		}
		
		newQ += " ";
		
		newQ += elements[randElement2].symbol;
		if(randCharge2 != 1)
		{
			newQ += superscriptSigns[randSign2];
			newQ += superscripts[randCharge2];
		}
		if(randQuantity2 > 1)
		{
			newQ += subscripts[randQuantity2];
		}
		
		return newQ;
	}
	
	public void AnswerClicked(int answerNum)
	{
		if(questions[cQuestion].individualQuestions[iQuestionIndex].answers[answerNum].correct == true)
		{
			Debug.Log("Answer " + (answerNum + 1) + " is correct!");
			PrepForGame();
		}
		else
		{
			Debug.Log("Answer " + (answerNum + 1) + " is incorrect!");
			PrepForDead();
		}
		ResetQuestion();
	}
	
	private void RandomizeArray(Answer[] arr)
	{
		for (var i = arr.Length - 1; i > 0; i--)
		{
			var r = Random.Range(0,i);
			var tmp = arr[i];
			arr[i] = arr[r];
			arr[r] = tmp;
		}
	}
	
	private ParseVar[] AddItemToArray(this ParseVar[] original, ParseVar itemToAdd)
	{
		ParseVar[] finalArray = new ParseVar[original.Length + 1];
		for(int i = 0; i < original.Length; i++)
		{
			finalArray[i] = original[i];
		}
		finalArray[finalArray.Length - 1] = itemToAdd;
		return finalArray;
	}
	private int[] AddItemToArray(this int[] original, int itemToAdd)
	{
		int[] finalArray = new int[original.Length + 1];
		for(int i = 0; i < original.Length; i++)
		{
			finalArray[i] = original[i];
		}
		finalArray[finalArray.Length - 1] = itemToAdd;
		return finalArray;
	}
	
	private int PickFromList(int[] sourceArray)
	{
		int cItem = -1; //chosen item
		
		float total = 0.0f;
		for(int i = 0; i < sourceArray.Length; i++)
		{
			total += (float) sourceArray[i];
		}

		float selector = Random.Range(0.0f, total);
		float runningTotal = 0.0f;

		for(int i = 0; i < sourceArray.Length; i++)
		{
			float nextTotal = runningTotal + (float) sourceArray[i];
			
			if(selector >= runningTotal && selector < nextTotal)
			{
				cItem = i;
				break;
			}
			runningTotal = nextTotal;
		}
		
		return cItem;
	}
	
	private int PickFromList(Vector2[] sourceArray)
	{
		int cItem = -1; //chosen item
		
		float total = 0.0f;
		for(int i = 0; i < sourceArray.Length; i++)
		{
			if((int) sourceArray[i].x != -1)
			{
				total += (float) sourceArray[i].y;
			}
		}
		
		float selector = Random.Range(0.0f, total);
		float runningTotal = 0.0f;
		
		for(int i = 0; i < sourceArray.Length; i++)
		{
			if((int) sourceArray[i].x != -1)
			{
				float nextTotal = runningTotal + sourceArray[i].y;
				
				if(selector >= runningTotal && selector < nextTotal)
				{
					cItem = (int) sourceArray[i].x;
					break;
				}
				runningTotal = nextTotal;
			}
		}
		
		return cItem;
	}
	
	private void AddPVar(string vName, string vType, string vValue)
	{
		for(int i = 0; i < pVars.Length; i++)
		{
			if(pVars[i].varName == "")
			{
				//pVars[i].varName = vName;
				//pVars[i].value = vValue;
				pVars[i] = new ParseVar(vName, vType, vValue);
				break;
			}
		}
	}
	private int AddPVarRet(string vName, string vType, string vValue)
	{
		int newPVar = -1;
		for(int i = 0; i < pVars.Length; i++)
		{
			if(pVars[i].varName == "")
			{
				//pVars[i].varName = vName;
				//pVars[i].value = vValue;
				pVars[i] = new ParseVar(vName, vType, vValue);
				newPVar = i;
				break;
			}
		}
		return newPVar;
	}
	
	private ParseVar GetPVar(string vName)
	{
		ParseVar retVal = new ParseVar("", "", "");
		for(int i = 0; i < pVars.Length; i++)
		{
			if(pVars[i].varName == vName)
			{
				retVal = pVars[i];
				break;
			}
		}
		return retVal;
	}
	
	private string ParseQuestion(string qParam)
	{
		string finalQuestion = "";
		string finalRet = "";
		
		int escCount = 0; //get the number of commands in the question - can be an overshoot in the number, but there has to be a minimum - 1 command ~= 1 element used
		for(int c = 0; c < qParam.Length; c++)
		{
			if(qParam[c] == '*' || qParam[c] == '$')
			{
				escCount++;
			}
		}
		
		int[] locallyUsedElements = new int[escCount];
		
		for(int y = 0; y < escCount; y++)
		{
			pVars = AddItemToArray(pVars, new ParseVar("", "", ""));
		}
		
		int nl = 0;
		while(nl < qParam.Length)
		{
			if(qParam[nl] == '*' && nl < (qParam.Length - 3) && nl < (qParam.Length - (char.GetNumericValue(qParam[nl + 3]) + 3))) //arbitrary escape character - use next characters for command
			{
				int found = -1;
				int rCharge = -1;
				int rQuantity = -1;
				string finalName = "";
				string molecularPrefix = "";
				string commandRet = "";
				bool showParentheses = false;
				switch("" + qParam[nl + 1] + qParam[nl + 2])
				{
					case "i1": //ionic element symbol 1
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(metals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0/* && Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))*/ && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += elements[found].symbol; //element symbol
						if(rCharge > 0) //positive sign if positive
						{
							finalQuestion += superscriptSigns[0];
						}
						else if(rCharge < 0) //negative sign if negative
						{
							finalQuestion += superscriptSigns[1];
						}
						if(Mathf.Abs(rCharge) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
						{
							finalQuestion += superscripts[Mathf.Abs(rCharge)];
						}
						/*if(randQuantity1 > 1)
						{
							finalQuestion += subscripts[randQuantity1];
						}*/
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "i2": //ionic element symbol 2
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H") //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += elements[found].symbol; //element symbol
						if(rCharge > 0) //positive sign if positive
						{
							finalQuestion += superscriptSigns[0];
						}
						else if(rCharge < 0) //negative sign if negative
						{
							finalQuestion += superscriptSigns[1];
						}
						if(Mathf.Abs(rCharge) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
						{
							finalQuestion += superscripts[Mathf.Abs(rCharge)];
						}
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "I1": //ionic element name 1
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(metals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
							showParentheses = true;
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += elements[found].name; //element name
						if(showParentheses == true) //show the roman numeral display of the charge used if there are multiple possibilities
						{
							finalQuestion += " (" + romanNumerals[Mathf.Abs(rCharge)] + ")";
						}
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "I2": //ionic element name 2
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))))
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H" && System.Array.IndexOf(usedElements, r + 1) < 0) //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
							//showParentheses = true; //not needed - this is a nonmetal (not multivalent)
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += elements[found].baseName + "ide"; //element name
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "m1": //molecular element symbol 1
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0)
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H" && System.Array.IndexOf(usedElements, r + 1) < 0) //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rQuantity = Random.Range(1, 10);
						
						finalRet += "; " + rQuantity; //add the quantity used
						commandRet += "; " + rQuantity;
						
						finalQuestion += elements[found].symbol; //element symbol
						if(rQuantity != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
						{
							finalQuestion += subscripts[rQuantity];
						}
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "m2": //molecular element symbol 2
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0)
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H" && System.Array.IndexOf(usedElements, r + 1) < 0) //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rQuantity = Random.Range(1, 10);
						
						finalRet += "; " + rQuantity; //add the quantity used
						commandRet += "; " + rQuantity;
						
						finalQuestion += elements[found].symbol; //element symbol
						if(rQuantity != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
						{
							finalQuestion += subscripts[rQuantity];
						}
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "M1": //molecular element name 1
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0)
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H" && System.Array.IndexOf(usedElements, r + 1) < 0) //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rQuantity = Random.Range(1, 10);
						
						finalRet += "; " + rQuantity; //add the quantity used
						commandRet += "; " + rQuantity;
						
						if(rQuantity != 1)
						{
							molecularPrefix = molecularPrefixes[rQuantity];
							if(molecularPrefixesVowelRemove[rQuantity] == true && System.Array.IndexOf(vowels, elements[found].name.ToLower()[0]) >= 0)
							{
								molecularPrefix = molecularPrefix.Substring(0, molecularPrefix.Length - 1);
							}
						}
						finalName = molecularPrefix + elements[found].name; //element name
						finalName = finalName[0].ToString().ToUpper() + finalName.Substring(1).ToLower();
						finalQuestion += finalName;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "M2": //molecular element name 2
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0)
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H" && System.Array.IndexOf(usedElements, r + 1) < 0) //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rQuantity = Random.Range(1, 10);
						
						finalRet += "; " + rQuantity; //add the quantity used
						commandRet += "; " + rQuantity;
						
						molecularPrefix = molecularPrefixes[rQuantity];
						if(molecularPrefixesVowelRemove[rQuantity] == true && System.Array.IndexOf(vowels, elements[found].baseName.ToLower()[0]) >= 0)
						{
							molecularPrefix = molecularPrefix.Substring(0, molecularPrefix.Length - 1);
						}
						finalName = molecularPrefix + elements[found].baseName + "ide"; //element name
						finalName = finalName[0].ToString().ToUpper() + finalName.Substring(1).ToLower();
						finalQuestion += finalName;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "q1": //polyatomic compound symbols 1 - either positive or negative
						//found = Random.Range(0, polyatomicCompounds.Length);
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if(System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//polyatomic compound symbols & quantities
						finalQuestion += "(";
						for(int p = 0; p < polyatomicCompounds[found].symbols.Length; p++)
						{
							finalQuestion += elements[polyatomicCompounds[found].symbols[p]].symbol;
							if(polyatomicCompounds[found].quantities[p] != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[polyatomicCompounds[found].quantities[p]];
							}
						}
						finalQuestion += ")";
						
						if(rCharge > 0) //positive sign if positive
						{
							finalQuestion += superscriptSigns[0];
						}
						else if(rCharge < 0) //negative sign if negative
						{
							finalQuestion += superscriptSigns[1];
						}
						if(Mathf.Abs(rCharge) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
						{
							finalQuestion += superscripts[Mathf.Abs(rCharge)];
						}
						
						//usedPolies[System.Array.IndexOf(usedPolies, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "Q1": //polyatomic compound name 1 - either positive or negative
						//found = Random.Range(0, polyatomicCompounds.Length);
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if(System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						finalQuestion += polyatomicCompounds[found].name; //polyatomic compound name
						
						//usedPolies[System.Array.IndexOf(usedPolies, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "p1": //polyatomic compound symbols 1 - positive
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if(polyatomicCompounds[r].charge > 0 && System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//polyatomic compound symbols & quantities
						finalQuestion += "(";
						for(int p = 0; p < polyatomicCompounds[found].symbols.Length; p++)
						{
							finalQuestion += elements[polyatomicCompounds[found].symbols[p]].symbol;
							if(polyatomicCompounds[found].quantities[p] != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[polyatomicCompounds[found].quantities[p]];
							}
						}
						finalQuestion += ")";
						
						if(rCharge > 0) //positive sign if positive
						{
							finalQuestion += superscriptSigns[0];
						}
						else if(rCharge < 0) //negative sign if negative
						{
							finalQuestion += superscriptSigns[1];
						}
						if(Mathf.Abs(rCharge) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
						{
							finalQuestion += superscripts[Mathf.Abs(rCharge)];
						}
						
						//usedPolies[System.Array.IndexOf(usedPolies, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "P1": //polyatomic compound name 1 - positive
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if(polyatomicCompounds[r].charge > 0 && System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						finalQuestion += polyatomicCompounds[found].name; //polyatomic compound name
						
						//usedPolies[System.Array.IndexOf(usedPolies, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "p2": //polyatomic compound symbols 2 - negative
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if(polyatomicCompounds[r].charge < 0 && System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//polyatomic compound symbols & quantities
						finalQuestion += "(";
						for(int p = 0; p < polyatomicCompounds[found].symbols.Length; p++)
						{
							finalQuestion += elements[polyatomicCompounds[found].symbols[p]].symbol;
							if(polyatomicCompounds[found].quantities[p] != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[polyatomicCompounds[found].quantities[p]];
							}
						}
						finalQuestion += ")";
						
						if(rCharge > 0) //positive sign if positive
						{
							finalQuestion += superscriptSigns[0];
						}
						else if(rCharge < 0) //negative sign if negative
						{
							finalQuestion += superscriptSigns[1];
						}
						if(Mathf.Abs(rCharge) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
						{
							finalQuestion += superscripts[Mathf.Abs(rCharge)];
						}
						
						//usedPolies[System.Array.IndexOf(usedPolies, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "P2": //polyatomic compound name 2 - positive
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if(polyatomicCompounds[r].charge < 0 && System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						finalQuestion += polyatomicCompounds[found].name; //polyatomic compound name
						
						//usedPolies[System.Array.IndexOf(usedPolies, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "a1": //binary acid symbol part 1
						found = 0; //hydrogen
						finalRet += found + "; " + 1;
						commandRet += found + "; " + 1;
						
						finalQuestion += elements[found].symbol;
						
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "a2": //binary acid symbol part 2
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H" && elements[r].symbol != "O") //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative), and do not allow oxygen (makes water - not an acid)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += elements[found].symbol; //element symbol
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "a3": //oxyacid symbol part 1
						found = 0; //hydrogen
						finalRet += found + "; " + 1;
						commandRet += found + "; " + 1;
						
						finalQuestion += elements[found].symbol;
						
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "a4": //oxyacid symbol part 2
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if(polyatomicCompounds[r].name.Substring(polyatomicCompounds[r].name.Length - 3, 3) == "ate" && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//polyatomic compound symbols & quantities
						finalQuestion += "(";
						for(int p = 0; p < polyatomicCompounds[found].symbols.Length; p++)
						{
							finalQuestion += elements[polyatomicCompounds[found].symbols[p]].symbol;
							if(polyatomicCompounds[found].quantities[p] != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[polyatomicCompounds[found].quantities[p]];
							}
						}
						finalQuestion += ")";
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "a5": //base 1 symbol part 1
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(metals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += elements[found].symbol; //element symbol
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "a6": //base 1 symbol part 2
						found = 6;
						finalRet += found;
						commandRet += found;
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//polyatomic compound symbols & quantities
						finalQuestion += "(";
						for(int p = 0; p < polyatomicCompounds[found].symbols.Length; p++)
						{
							finalQuestion += elements[polyatomicCompounds[found].symbols[p]].symbol;
							if(polyatomicCompounds[found].quantities[p] != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[polyatomicCompounds[found].quantities[p]];
							}
						}
						finalQuestion += ")";
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "a7": //base 2 symbol part 1
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(metals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += elements[found].symbol; //element symbol
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "a8": //base 2 symbol part 2
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if((polyatomicCompounds[r].name.Length >= 9 && polyatomicCompounds[r].name.Substring(0, 9).ToLower() == "hydrogen-") && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//polyatomic compound symbols & quantities
						finalQuestion += "(";
						for(int p = 0; p < polyatomicCompounds[found].symbols.Length; p++)
						{
							finalQuestion += elements[polyatomicCompounds[found].symbols[p]].symbol;
							if(polyatomicCompounds[found].quantities[p] != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[polyatomicCompounds[found].quantities[p]];
							}
						}
						finalQuestion += ")";
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "A1": //binary acid name part 1
						found = 0; //hydrogen
						finalRet += found + "; " + 1;
						commandRet += found + "; " + 1;
						
						finalQuestion += "Hydro";
						
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "A2": //binary acid name part 2
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H" && elements[r].symbol != "O") //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative), and do not allow oxygen (makes water - not an acid)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						if(elements[found].baseName.ToLower()[0] == 'o')
						{
							finalQuestion = finalQuestion.Substring(0, finalQuestion.Length - 1);
						}
						finalQuestion += elements[found].baseName.ToLower() + "ic Acid"; //element symbol
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "A3": //oxyacid name part 1
						found = 0; //hydrogen
						finalRet += found + "; " + 1;
						commandRet += found + "; " + 1;
						
						//finalQuestion += elements[found].symbol; //adds absolutely nothing. hydrogen gets dropped entirely from the name with oxyacids.
						
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "A4": //oxyacid name part 2
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if(polyatomicCompounds[r].name.Substring(polyatomicCompounds[r].name.Length - 3, 3).ToLower() == "ate" && (polyatomicCompounds[r].name.Length < 9 || polyatomicCompounds[r].name.Substring(0, 9).ToLower() != "hydrogen-") && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += polyatomicCompounds[found].name.Substring(0, polyatomicCompounds[found].name.Length - 3) + "ic Acid";
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "A5": //base 1 name part 1
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(metals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
							showParentheses = true;
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += elements[found].name; //element name
						if(showParentheses == true) //show the roman numeral display of the charge used if there are multiple possibilities
						{
							finalQuestion += " (" + romanNumerals[Mathf.Abs(rCharge)] + ")";
						}
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "A6": //base 1 name part 2
						found = 6;
						finalRet += found;
						commandRet += found;
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += polyatomicCompounds[found].name;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "A7": //base 2 name part 1
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(metals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
							showParentheses = true;
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += elements[found].name; //element name
						if(showParentheses == true) //show the roman numeral display of the charge used if there are multiple possibilities
						{
							finalQuestion += " (" + romanNumerals[Mathf.Abs(rCharge)] + ")";
						}
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "A8": //base 2 name part 2
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if((polyatomicCompounds[r].name.Length >= 9 && polyatomicCompounds[r].name.Substring(0, 9).ToLower() == "hydrogen-") && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						finalQuestion += polyatomicCompounds[found].name;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "B2": //empty diagram
						found = 0;
						finalRet += found;
						commandRet += found;
						
						finalQuestion += found;
						
						finalRet += " : ";
						break;
					case "b1": //bohr-rutherford diagram - stable
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, questionDiagrams.Length);
							if(questionDiagrams[r].diagramType == DiagramType.BohrRutherford && questionDiagrams[r].stable == true && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "b2": //bohr-rutherford diagram - unstable
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, questionDiagrams.Length);
							if(questionDiagrams[r].diagramType == DiagramType.BohrRutherford && questionDiagrams[r].stable == false && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "B1": //bohr-rutherford diagram - either
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, questionDiagrams.Length);
							if(questionDiagrams[r].diagramType == DiagramType.BohrRutherford && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "d1": //lewis-dot diagram - stable
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, questionDiagrams.Length);
							if(questionDiagrams[r].diagramType == DiagramType.LewisDot && questionDiagrams[r].stable == true && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "d2": //lewis-dot diagram - unstable
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, questionDiagrams.Length);
							if(questionDiagrams[r].diagramType == DiagramType.LewisDot && questionDiagrams[r].stable == false && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "D1": //lewis-dot diagram - either
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, questionDiagrams.Length);
							if(questionDiagrams[r].diagramType == DiagramType.LewisDot && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "w1": //WHMIS symbol
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, questionDiagrams.Length);
							if(questionDiagrams[r].diagramType == DiagramType.SafetySymbol && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W1": //WHMIS symbol - flammable
						found = 15;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W2": //WHMIS symbol - explosive
						found = 14;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W3": //WHMIS symbol - environment
						found = 13;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W4": //WHMIS symbol - irritant
						found = 17;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W5": //WHMIS symbol - compressed gas
						found = 11;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W6": //WHMIS symbol - corrosive
						found = 12;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W7": //WHMIS symbol - hazardous health effect
						found = 16;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W8": //WHMIS symbol - oxidizer
						found = 18;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W9": //WHMIS symbol - toxic
						found = 19;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
				}
				string pVarName = "";
				if(char.GetNumericValue(qParam[nl + 3]) > 0)
				{
					for(int n = 0; n < char.GetNumericValue(qParam[nl + 3]); n++)
					{
						pVarName += qParam[nl + 3 + 1 + n];
					}
				}
				else
				{
					pVarName = "" + qParam[nl + 1] + qParam[nl + 2];
				}
				AddPVar(pVarName, "" + qParam[nl + 1] + qParam[nl + 2], commandRet);
				nl += 2 + (int) char.GetNumericValue(qParam[nl + 3]) + 1;
			}
			else if(qParam[nl] == '$' && nl < (qParam.Length - 3) && nl < (qParam.Length - (char.GetNumericValue(qParam[nl + 3]) + 3))) //arbitrary escape character - use next characters for setting the variables
			{
				int found = -1;
				int rCharge = -1;
				int rQuantity = -1;
				string commandRet = "";
				
				switch("" + qParam[nl + 1] + qParam[nl + 2])
				{
					case "i1": //ionic element 1
					case "I1":
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(metals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "i2": //ionic element 2
					case "I2":
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))))
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H") //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "m1": //molecular element 1
					case "M1":
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0)
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H" && System.Array.IndexOf(usedElements, r + 1) < 0) //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rQuantity = Random.Range(1, 10);
						
						finalRet += "; " + rQuantity; //add the quantity used
						commandRet += "; " + rQuantity;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "m2": //molecular element symbol 2
					case "M2":
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0)
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H" && System.Array.IndexOf(usedElements, r + 1) < 0) //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rQuantity = Random.Range(1, 10);
						
						finalRet += "; " + rQuantity; //add the quantity used
						commandRet += "; " + rQuantity;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "q1": //polyatomic compound symbols 1 - either positive or negative
					case "Q1":
						found = Random.Range(0, polyatomicCompounds.Length);
						finalRet += found;
						commandRet += found;
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//usedPolies[System.Array.IndexOf(usedPolies, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "p1": //polyatomic compound symbols 1 - positive
					case "P1":
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if(polyatomicCompounds[r].charge > 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//usedPolies[System.Array.IndexOf(usedPolies, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "p2": //polyatomic compound symbols 1 - negative
					case "P2":
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if(polyatomicCompounds[r].charge < 0)
							{
								found = r;
							}
						}
						finalRet += found;
						commandRet += found;
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//usedPolies[System.Array.IndexOf(usedPolies, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "a1": //binary acid part 1
					case "A1":
						found = 0; //hydrogen
						finalRet += found + "; " + 1;
						commandRet += found + "; " + 1;
						
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "a2": //binary acid part 2
					case "A2":
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(nonmetals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								if(System.Array.IndexOf(elements[r].commonCharges, 0) < 0 && elements[r].symbol != "H" && elements[r].symbol != "O") //do not allow elements with 0 as a possible charge, and do not allow hydrogen (can be positive or negative), and do not allow oxygen (makes water - not an acid)
								{
									found = r;
									finalRet += r;
									commandRet += r;
								}
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "a3": //oxyacid part 1
					case "A3":
						found = 0; //hydrogen
						finalRet += found + "; " + 1;
						commandRet += found + "; " + 1;
						
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "a4": //oxyacid part 2
					case "A4":
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if(polyatomicCompounds[r].name.Substring(polyatomicCompounds[r].name.Length - 3, 3) == "ate" && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "a5": //base 1 part 1
					case "A5":
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(metals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "a6": //base 1 part 2
					case "A6":
						found = 6;
						finalRet += found;
						commandRet += found;
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "a7": //base 2 part 1
					case "A7":
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, elements.Length);
							if(System.Array.IndexOf(metals, elements[r].type) > -1 && elements[r].commonCharges.Length > 0 && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = elements[found].commonCharges[0];
						if(elements[found].commonCharges.Length > 1)
						{
							rCharge = elements[found].commonCharges[Random.Range(0, elements[found].commonCharges.Length)];
						}
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "a8": //base 2 part 2
					case "A8":
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, polyatomicCompounds.Length);
							if((polyatomicCompounds[r].name.Length >= 9 && polyatomicCompounds[r].name.Substring(0, 9).ToLower() == "hydrogen-") && (finalRet.Length <= 0 || Mathf.Abs(elements[r].commonCharges[0]) != Mathf.Abs(int.Parse(finalRet.Substring(0, finalRet.Length - 3).Split(new string[] {" : "}, System.StringSplitOptions.None).Last().Split(new string[] {"; "}, System.StringSplitOptions.None).Last()))) && System.Array.IndexOf(usedPolies, r + 1) < 0)
							{
								found = r;
								finalRet += r;
								commandRet += r;
							}
						}
						
						rCharge = polyatomicCompounds[found].charge;
						
						finalRet += "; " + rCharge; //add the charge used
						commandRet += "; " + rCharge;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedPolies = AddItemToArray(usedPolies, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
					break;
					case "w1": //WHMIS symbol
						found = -1;
						while(found < 0)
						{
							int r = Random.Range(0, questionDiagrams.Length);
							if(questionDiagrams[r].diagramType == DiagramType.SafetySymbol && System.Array.IndexOf(usedElements, r + 1) < 0)
							{
								found = r;
							}
						}
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						finalQuestion += found;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W1": //WHMIS symbol - flammable
						found = 15;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W2": //WHMIS symbol - explosive
						found = 14;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W3": //WHMIS symbol - environment
						found = 13;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W4": //WHMIS symbol - irritant
						found = 17;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W5": //WHMIS symbol - compressed gas
						found = 11;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W6": //WHMIS symbol - corrosive
						found = 12;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W7": //WHMIS symbol - hazardous health effect
						found = 16;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W8": //WHMIS symbol - oxidizer
						found = 18;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
					case "W9": //WHMIS symbol - toxic
						found = 19;
						finalRet += found + "; " + 0;
						commandRet += found + "; " + 0;
						
						//usedElements[System.Array.IndexOf(usedElements, 0)] = found + 1;
						usedElements = AddItemToArray(usedElements, found + 1);
						locallyUsedElements = AddItemToArray(locallyUsedElements, found + 1);
						
						finalRet += " : ";
						break;
				}
				string pVarName = "";
				if(char.GetNumericValue(qParam[nl + 3]) > 0)
				{
					for(int n = 0; n < char.GetNumericValue(qParam[nl + 3]); n++)
					{
						pVarName += qParam[nl + 3 + 1 + n];
					}
				}
				else
				{
					pVarName = "" + qParam[nl + 1] + qParam[nl + 2];
				}
				AddPVar(pVarName, "" + qParam[nl + 1] + qParam[nl + 2], commandRet);
				//Debug.Log("Here goes: " + pVarName + " | " + "" + qParam[nl + 1] + qParam[nl + 2] + " | " + commandRet + " | " + GetPVar(pVarName).value);
				nl += 2 + (int) char.GetNumericValue(qParam[nl + 3]) + 1;
			}
			else if(qParam[nl] == '^' && nl < (qParam.Length - 1) && nl < (qParam.Length - (char.GetNumericValue(qParam[nl + 1]) + 1))) //arbitrary escape character - use next characters for variable name
			{
				int pVarNameLength = (int) char.GetNumericValue(qParam[nl + 1]);
				char handlingType = qParam[nl + pVarNameLength + 2];
				
				//store the variable name
				string pVarName = qParam.Substring(nl + 1 + 1, pVarNameLength);/*"";
				if(pVarNameLength > 0)
				{
					for(int n = 0; n < pVarNameLength; n++)
					{
						pVarName += qParam[nl + 1 + 1 + n];
					}
				}*/
				//Debug.LogWarning(GetPVar(pVarName).value + " : " + handlingType);
				
				ParseVar pVar = GetPVar(pVarName); //stored variable value
				string[] pValues = pVar.value.Split(new string[] {" : "}, System.StringSplitOptions.None);
				string[] pValues0Split = pValues[0].Split(new string[] {"; "}, System.StringSplitOptions.None);
				int pNum1 = int.Parse(pValues0Split[0]);
				int pNum2 = int.Parse(pValues0Split[1]);
				switch(pVar.type) //handle different things based on what the variable is
				{
					case "i1": //ionic element symbol 1
					case "I1": //ionic element name 1
						finalRet += pNum1 + "; " + pNum2 + " : ";
						
						if(handlingType == 's') //symbol as a whole
						{
							finalQuestion += elements[pNum1].symbol; //element symbol
							if(pNum2 > 0) //positive sign if positive
							{
								finalQuestion += superscriptSigns[0];
							}
							else if(pNum2 < 0) //negative sign if negative
							{
								finalQuestion += superscriptSigns[1];
							}
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += superscripts[Mathf.Abs(pNum2)];
							}
						}
						else if(handlingType == 'S') //just the symbol
						{
							finalQuestion += elements[pNum1].symbol; //element symbol
						}
						else if(handlingType == 'C') //just the charge
						{
							if(pNum2 > 0) //positive sign if positive
							{
								finalQuestion += superscriptSigns[0];
							}
							else if(pNum2 < 0) //negative sign if negative
							{
								finalQuestion += superscriptSigns[1];
							}
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += superscripts[Mathf.Abs(pNum2)];
							}
						}
						else if(handlingType == 'O') //charge converted to a quantity
						{
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[Mathf.Abs(pNum2)];
							}
						}
						else if(handlingType == 'n')
						{
							finalQuestion += elements[pNum1].name; //element name
							if(elements[pNum1].commonCharges.Length > 1) //show the roman numeral display of the charge used if there are multiple possibilities
							{
								finalQuestion += " (" + romanNumerals[Mathf.Abs(pNum2)] + ")";
							}
						}
						else if(handlingType == 'N') //name, but treated as though it is a nonmetal
						{
							finalQuestion += elements[pNum1].baseName + "ide"; //element name
						}
						else if(handlingType == 'r') //name without roman numerals
						{
							finalQuestion += elements[pNum1].name; //element name
						}
						else if(handlingType == 'R') //just roman numerals
						{
							if(elements[pNum1].commonCharges.Length > 1) //show the roman numeral display of the charge used if there are multiple possibilities
							{
								finalQuestion += " (" + romanNumerals[Mathf.Abs(pNum2)] + ")";
							}
						}
						else if(handlingType == 'k') //inverted roman numerals conditions
						{
							if(elements[pNum1].commonCharges.Length <= 1) //show the roman numeral display of the charge used if there is only one possibility
							{
								finalQuestion += " (" + romanNumerals[Mathf.Abs(pNum2)] + ")";
							}
						}
						else if(handlingType == 'K') //roman numerals, whether necessary or not
						{
							finalQuestion += " (" + romanNumerals[Mathf.Abs(pNum2)] + ")";
						}
					break;
					case "i2": //ionic element symbol 2
					case "I2": //ionic element name 2
						finalRet += pNum1 + "; " + pNum2 + " : ";
						
						if(handlingType == 's')
						{
							finalQuestion += elements[pNum1].symbol; //element symbol
							if(pNum2 > 0) //positive sign if positive
							{
								finalQuestion += superscriptSigns[0];
							}
							else if(pNum2 < 0) //negative sign if negative
							{
								finalQuestion += superscriptSigns[1];
							}
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += superscripts[Mathf.Abs(pNum2)];
							}
						}
						else if(handlingType == 'S') //just the symbol
						{
							finalQuestion += elements[pNum1].symbol; //element symbol
						}
						else if(handlingType == 'C') //just the charge
						{
							if(pNum2 > 0) //positive sign if positive
							{
								finalQuestion += superscriptSigns[0];
							}
							else if(pNum2 < 0) //negative sign if negative
							{
								finalQuestion += superscriptSigns[1];
							}
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += superscripts[Mathf.Abs(pNum2)];
							}
						}
						else if(handlingType == 'O') //charge converted to a quantity
						{
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[Mathf.Abs(pNum2)];
							}
						}
						else if(handlingType == 'n')
						{
							finalQuestion += elements[pNum1].baseName + "ide"; //element name
						}
						else if(handlingType == 'N') //name, but treated as though it is a metal
						{
							finalQuestion += elements[pNum1].name; //element name
							if(elements[pNum1].commonCharges.Length > 1) //show the roman numeral display of the charge used if there are multiple possibilities
							{
								finalQuestion += " (" + romanNumerals[Mathf.Abs(pNum2)] + ")";
							}
						}
					break;
					case "m1": //molecular element symbol 1
					case "M1": //molecular element name 1
						finalRet += pNum1 + "; " + pNum2 + " : ";
						
						if(handlingType == 's')
						{
							finalQuestion += elements[pNum1].symbol; //element symbol
							if(pNum2 != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[pNum2];
							}
						}
						else if(handlingType == 'n')
						{
							string molecularPrefix = "";
							if(pNum2 != 1)
							{
								molecularPrefix = molecularPrefixes[pNum2];
								if(molecularPrefixesVowelRemove[pNum2] == true && System.Array.IndexOf(vowels, elements[pNum1].name.ToLower()[0]) >= 0)
								{
									molecularPrefix = molecularPrefix.Substring(0, molecularPrefix.Length - 1);
								}
							}
							string finalName = molecularPrefix + elements[pNum1].name; //element name
							finalName = finalName[0].ToString().ToUpper() + finalName.Substring(1).ToLower();
							finalQuestion += finalName;
						}
					break;
					case "m2": //molecular element symbol 2
					case "M2": //molecular element name 2
						finalRet += pNum1 + "; " + pNum2 + " : ";
						
						if(handlingType == 's')
						{
							finalQuestion += elements[pNum1].symbol; //element symbol
							if(pNum2 != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[pNum2];
							}
						}
						else if(handlingType == 'n')
						{
							string molecularPrefix = molecularPrefixes[pNum2];
							if(molecularPrefixesVowelRemove[pNum2] == true && System.Array.IndexOf(vowels, elements[pNum1].baseName.ToLower()[0]) >= 0)
							{
								molecularPrefix = molecularPrefix.Substring(0, molecularPrefix.Length - 1);
							}
							string finalName = molecularPrefix + elements[pNum1].baseName + "ide"; //element name
							finalName = finalName[0].ToString().ToUpper() + finalName.Substring(1).ToLower();
							finalQuestion += finalName;
						}
					break;
					case "q1": //polyatomic compounds
					case "Q1":
					case "p1":
					case "P1":
					case "p2":
					case "P2":
						finalRet += pNum1 + "; " + pNum2 + " : ";
						
						if(handlingType == 's')
						{
							//polyatomic compound symbols & quantities
							finalQuestion += "(";
							for(int p = 0; p < polyatomicCompounds[pNum1].symbols.Length; p++)
							{
								finalQuestion += elements[polyatomicCompounds[pNum1].symbols[p]].symbol;
								if(polyatomicCompounds[pNum1].quantities[p] != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
								{
									finalQuestion += subscripts[polyatomicCompounds[pNum1].quantities[p]];
								}
							}
							finalQuestion += ")";
							
							if(pNum2 > 0) //positive sign if positive
							{
								finalQuestion += superscriptSigns[0];
							}
							else if(pNum2 < 0) //negative sign if negative
							{
								finalQuestion += superscriptSigns[1];
							}
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += superscripts[Mathf.Abs(pNum2)];
							}
						}
						else if(handlingType == 'S') //just the symbol
						{
							//polyatomic compound symbols & quantities
							finalQuestion += "(";
							for(int p = 0; p < polyatomicCompounds[pNum1].symbols.Length; p++)
							{
								finalQuestion += elements[polyatomicCompounds[pNum1].symbols[p]].symbol;
								if(polyatomicCompounds[pNum1].quantities[p] != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
								{
									finalQuestion += subscripts[polyatomicCompounds[pNum1].quantities[p]];
								}
							}
							finalQuestion += ")";
						}
						else if(handlingType == 'C') //just the charge
						{
							if(pNum2 > 0) //positive sign if positive
							{
								finalQuestion += superscriptSigns[0];
							}
							else if(pNum2 < 0) //negative sign if negative
							{
								finalQuestion += superscriptSigns[1];
							}
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += superscripts[Mathf.Abs(pNum2)];
							}
						}
						else if(handlingType == 'O') //charge converted to a quantity
						{
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[Mathf.Abs(pNum2)];
							}
						}
						else if(handlingType == 'n')
						{
							finalQuestion += polyatomicCompounds[pNum1].name; //polyatomic compound name
						}
					break;
					case "a1": //binary acid part 1
					case "A1":
						if(handlingType == 's' || handlingType == 'S')
						{
							finalQuestion += elements[pNum1].symbol;
						}
						else if(handlingType == 'n')
						{
							finalQuestion += "Hydro";
						}
						else if(handlingType == 'O') //charge converted to a quantity
						{
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[Mathf.Abs(pNum2)];
							}
						}
					break;
					case "a2": //binary acid part 2
					case "A2":
						if(handlingType == 's' || handlingType == 'S')
						{
							finalQuestion += elements[pNum1].symbol;
						}
						else if(handlingType == 'n')
						{
							//if(System.Array.IndexOf(vowels, elements[pNum1].baseName[0]) >= 0)
							if(elements[pNum1].baseName.ToLower()[0] == 'o')
							{
								finalQuestion = finalQuestion.Substring(0, finalQuestion.Length - 1);
							}
							finalQuestion += elements[pNum1].baseName.ToLower() + "ic Acid";
						}
						else if(handlingType == 'O') //charge converted to a quantity
						{
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[Mathf.Abs(pNum2)];
							}
						}
					break;
					case "a3": //oxyacid part 1
					case "A3":
						if(handlingType == 's' || handlingType == 'S')
						{
							finalQuestion += elements[pNum1].symbol;
						}
						else if(handlingType == 'n')
						{
							//adds absolutely nothing. hydrogen gets dropped entirely from the name with oxyacids.
						}
						else if(handlingType == 'O') //charge converted to a quantity
						{
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[Mathf.Abs(pNum2)];
							}
						}
					break;
					case "a4": //oxyacid part 2
					case "A4":
						if(handlingType == 's' || handlingType == 'S')
						{
							finalQuestion += "(";
							for(int p = 0; p < polyatomicCompounds[pNum1].symbols.Length; p++)
							{
								finalQuestion += elements[polyatomicCompounds[pNum1].symbols[p]].symbol;
								if(polyatomicCompounds[pNum1].quantities[p] != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
								{
									finalQuestion += subscripts[polyatomicCompounds[pNum1].quantities[p]];
								}
							}
							finalQuestion += ")";
						}
						else if(handlingType == 'n')
						{
							finalQuestion += polyatomicCompounds[pNum1].name.Substring(0, polyatomicCompounds[pNum1].name.Length - 3) + "ic Acid";
						}
						else if(handlingType == 'O') //charge converted to a quantity
						{
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[Mathf.Abs(pNum2)];
							}
						}
					break;
					case "a5": //base 1 part 1
					case "A5":
						if(handlingType == 's' || handlingType == 'S')
						{
							finalQuestion += elements[pNum1].symbol; //element symbol
						}
						else if(handlingType == 'n')
						{
							finalQuestion += elements[pNum1].name; //element name
						}
						else if(handlingType == 'O') //charge converted to a quantity
						{
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[Mathf.Abs(pNum2)];
							}
						}
					break;
					case "a6": //base 1 part 2
					case "A6":
						if(handlingType == 's' || handlingType == 'S')
						{
							finalQuestion += "(";
							for(int p = 0; p < polyatomicCompounds[pNum1].symbols.Length; p++)
							{
								finalQuestion += elements[polyatomicCompounds[pNum1].symbols[p]].symbol;
								if(polyatomicCompounds[pNum1].quantities[p] != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
								{
									finalQuestion += subscripts[polyatomicCompounds[pNum1].quantities[p]];
								}
							}
							finalQuestion += ")";
						}
						else if(handlingType == 'n')
						{
							finalQuestion += polyatomicCompounds[pNum1].name;
						}
						else if(handlingType == 'O') //charge converted to a quantity
						{
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[Mathf.Abs(pNum2)];
							}
						}
					break;
					case "a7": //base 2 part 1
					case "A7":
						if(handlingType == 's' || handlingType == 'S')
						{
							finalQuestion += elements[pNum1].symbol; //element symbol
						}
						else if(handlingType == 'n')
						{
							finalQuestion += elements[pNum1].name; //element name
						}
						else if(handlingType == 'O') //charge converted to a quantity
						{
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[Mathf.Abs(pNum2)];
							}
						}
					break;
					case "a8": //base 2 part 2
					case "A8":
						if(handlingType == 's' || handlingType == 'S')
						{
							finalQuestion += "(";
							for(int p = 0; p < polyatomicCompounds[pNum1].symbols.Length; p++)
							{
								finalQuestion += elements[polyatomicCompounds[pNum1].symbols[p]].symbol;
								if(polyatomicCompounds[pNum1].quantities[p] != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
								{
									finalQuestion += subscripts[polyatomicCompounds[pNum1].quantities[p]];
								}
							}
							finalQuestion += ")";
						}
						else if(handlingType == 'n')
						{
							finalQuestion += polyatomicCompounds[pNum1].name;
						}
						else if(handlingType == 'O') //charge converted to a quantity
						{
							if(Mathf.Abs(pNum2) != 1) //in chemistry, 1 is implied if no value is shown. don't show 1 if singular.
							{
								finalQuestion += subscripts[Mathf.Abs(pNum2)];
							}
						}
					break;
					case "w1": //WHMIS symbol
					case "W1": //WHMIS symbol - flammable
					case "W2": //WHMIS symbol - explosive
					case "W3": //WHMIS symbol - environment
					case "W4": //WHMIS symbol - irritant
					case "W5": //WHMIS symbol - compressed gas
					case "W6": //WHMIS symbol - corrosive
					case "W7": //WHMIS symbol - hazardous health effect
					case "W8": //WHMIS symbol - oxidizer
					case "W9": //WHMIS symbol - toxic
						if(handlingType == 'i')
						{
							finalQuestion += pNum1;
						}
					break;
				}
				nl += pVarNameLength + 2;
			}
			else
			{
				finalQuestion += qParam[nl];
			}
			nl++;
		}
		finalRet += finalQuestion;
		return finalRet;
	}
}
