//<?php
//namespace app\helper\scribus;

//class titlepage {
//  private $_cobjScribus;
//  function __construct($Scribus) {
//    $this->$_cobjScribus = $Scribus;
//  }
//  function page() {
//    $this->_cobjScribus->addPage(0, "a5");
//  }
//  function congregation() {
//    /*$larrOptions = array(XPOS="128.346456692913"
//    YPOS="82.3622047244095"
//    OwnPage="0"
//    WIDTH="362.834645669291"
//    HEIGHT="56.6929133858268"
//    path="M0 0 L362.835 0 L362.835 56.6929 L0 56.6929 L0 0 Z" 
//    copath="M0 0 L362.835 0 L362.835 56.6929 L0 56.6929 L0 0 Z" 
//    gXpos="1.06299212598424" 
//    gYpos="-601.259842519685" 
//    gWidth="363.897637795275" 
//    gHeight="91.3700787401577");*/
//    $larrContent = array(
//      "Gemeindebrief" => 40,
//      array("   DIGITAL", 21, "Helvetica Neue Light Italic"),
//      "Erste Seite - Gemeindebrief - groß" => true,
//      "Buxtehude" => 18,
//      array("parent" => "Erste Seite - Gemeindebrief - klein", "align"=>"0")
//    );
//    $this->_cobjScribus->PageObject('textbox', $larrOptions, $larrContent);

    

    
//  }
//  function line() {
//    // <PAGEOBJECT XPOS="128.346456692913" YPOS="113.543307086614" OwnPage="0" ItemID="137970584" PTYPE="5" WIDTH="65.1968503937007" HEIGHT="1" FRTYPE="0" CLIPEDIT="0" ROT="270" PWIDTH="2.1259842519685" PCOLOR2="NAK-blau 100%" PLINEART="1" ANNAME="Kopie von Titelseite_Titel_Zierlinie" path="" gXpos="1.06299212598424" gYpos="-570.07874015748" gWidth="363.897637795275" gHeight="91.3700787401577" LAYER="0"/>
//  }
//  function YearMonth() {
//    /*<PAGEOBJECT XPOS="128.346456692913" YPOS="150.393700787402" OwnPage="0" ItemID="143230552" PTYPE="4" WIDTH="362.834645669291" HEIGHT="25.511811023622" FRTYPE="0" CLIPEDIT="0" PWIDTH="1" PLINEART="1" ANNAME="Kopie von Titelseite_Monat_Text" LOCALSCX="1" LOCALSCY="1" LOCALX="0" LOCALY="0" LOCALROT="0" PICART="1" SCALETYPE="1" RATIO="1" COLUMNS="1" COLGAP="0" AUTOTEXT="0" EXTRA="0" TEXTRA="0" BEXTRA="0" REXTRA="0" VAlign="1" FLOP="0" PLTSHOW="0" BASEOF="0" textPathType="0" textPathFlipped="0" path="M0 0 L362.835 0 L362.835 25.5118 L0 25.5118 L0 0 Z" copath="M0 0 L362.835 0 L362.835 25.5118 L0 25.5118 L0 0 Z" gXpos="0" gYpos="-637.102362204724" gWidth="362.834645669291" gHeight="25.511811023622" LAYER="0" NEXTITEM="-1" BACKITEM="-1">
//  <StoryText>
//  <DefaultStyle/>
//  <ITEXT FONTSIZE="28" CH="Mai 2019"/>
//  <trail PARENT="Erste Seite - Gemeindebrief - Monat"/>
//  </StoryText>
//  </PAGEOBJECT> */
//  }
//  function karitativLogo() {
//// <PAGEOBJECT XPOS="128.346456692913" YPOS="150.393700787402" OwnPage="0" ItemID="137947464" PTYPE="2" WIDTH="100.629921259843" HEIGHT="25.511811023622" FRTYPE="0" CLIPEDIT="0" PWIDTH="1" PLINEART="1" ANNAME="Kopie von Titelseite_Monat_KarLogo" LOCALSCX="0.0613264688067836" LOCALSCY="0.0613264688067836" LOCALX="0" LOCALY="0" LOCALROT="0" PICART="1" SCALETYPE="0" RATIO="1" Pagenumber="0" PFILE="../../../../../Bilder/Logos/Logo_NAK_karitativ_HQ.tiff" IRENDER="0" EMBEDDED="0" path="M0 0 L100.63 0 L100.63 25.5118 L0 25.5118 L0 0 Z" copath="M0 0 L100.63 0 L100.63 25.5118 L0 25.5118 L0 0 Z" gXpos="0" gYpos="-637.102362204724" gWidth="362.834645669291" gHeight="25.511811023622" LAYER="0" NEXTITEM="-1" BACKITEM="-1"/>
//  }
//  function monthlyWord() {
///*<PAGEOBJECT XPOS="221.889763779528" YPOS="473.543307086614" OwnPage="0" ItemID="143220792" PTYPE="4" WIDTH="269.291338582677" HEIGHT="56.6929133858268" FRTYPE="0" CLIPEDIT="0" PWIDTH="1" PLINEART="1" ANNAME="Kopie von Titelseite_Textwort" LOCALSCX="1" LOCALSCY="1" LOCALX="0" LOCALY="0" LOCALROT="0" PICART="1" SCALETYPE="1" RATIO="1" COLUMNS="1" COLGAP="0" AUTOTEXT="0" EXTRA="0" TEXTRA="0" BEXTRA="0" REXTRA="0" VAlign="0" FLOP="0" PLTSHOW="0" BASEOF="0" textPathType="0" textPathFlipped="0" path="M0 0 L269.291 0 L269.291 56.6929 L0 56.6929 L0 0 Z" copath="M0 0 L269.291 0 L269.291 56.6929 L0 56.6929 L0 0 Z" gXpos="221.889763779528" gYpos="-161.732283464566" gWidth="0" gHeight="0" LAYER="0" NEXTITEM="-1" BACKITEM="-1">
//<StoryText>
//<DefaultStyle/>
//<ITEXT CH="„… ihr werdet die Kraft des Heiligen Geistes empfangen, die auf euch kommen wird …“"/>
//<para PARENT="Erste Seite - Bibelzitat - Text"/>
//<ITEXT CH="Apostelgeschichte 1,8"/>
//<para PARENT="Erste Seite - Bibelzitat - Ort"/>
//</StoryText>
//</PAGEOBJECT>*/
//  }
//  function pictureCongregation() {
//// <PAGEOBJECT XPOS="128.346456692913" YPOS="181.574803149606" OwnPage="0" ItemID="137968272" PTYPE="2" WIDTH="362.834645669291" HEIGHT="283.464566929134" FRTYPE="0" CLIPEDIT="0" PWIDTH="1" PLINEART="3" ANNAME="Kopie von Titelseite_Gemeinde" LOCALSCX="0.24" LOCALSCY="0.24" LOCALX="-96.3779527559055" LOCALY="0" LOCALROT="0" PICART="1" SCALETYPE="1" RATIO="1" Pagenumber="0" PFILE="../../../../../Bilder/Kirchen/Kirche_Buxtehude_HQ.tif" PRFILE="Embedded ISO Coated v2 300% (ECI)" EPROF="Embedded ISO Coated v2 300% (ECI)" IRENDER="0" path="M0 0 L362.835 0 L362.835 283.465 L0 283.465 L0 0 Z" copath="M0 0 L362.835 0 L362.835 283.465 L0 283.465 L0 0 Z" gXpos="128.346456692913" gYpos="-453.700787401575" gWidth="0" gHeight="0" LAYER="0" NEXTITEM="-1" BACKITEM="-1"/>
//  }
//  function logo() {
//// <PAGEOBJECT XPOS="445.826771653539" YPOS="541.574803149609" OwnPage="0" ItemID="137972896" PTYPE="2" WIDTH="45.3543307086614" HEIGHT="45.3543307086614" FRTYPE="0" CLIPEDIT="0" PWIDTH="1" PLINEART="1" ANNAME="Titelseite_NAK_Logo" LOCALSCX="0.0384033282884517" LOCALSCY="0.0384033282884517" LOCALX="0" LOCALY="0" LOCALROT="0" PICART="1" SCALETYPE="0" RATIO="1" Pagenumber="0" PFILE="../../../../../Bilder/Logos/Logo_NAK_HQ.tif" PRFILE="Embedded ISO Coated v2 300% (ECI)" EPROF="Embedded ISO Coated v2 300% (ECI)" IRENDER="0" path="M0 0 L45.3543 0 L45.3543 45.3543 L0 45.3543 L0 0 Z" copath="M0 0 L45.3543 0 L45.3543 45.3543 L0 45.3543 L0 0 Z" gXpos="197.437007874011" gYpos="0" gWidth="242.791338582672" gHeight="45.3543307086615" LAYER="0" NEXTITEM="-1" BACKITEM="-1"/>
//  }
//  function nac() {
///*<PAGEOBJECT XPOS="247.40157480315" YPOS="558.582677165357" OwnPage="0" ItemID="143225672" PTYPE="4" WIDTH="187.086614173228" HEIGHT="28.3464566929134" FRTYPE="0" CLIPEDIT="0" PWIDTH="1" PLINEART="1" ANNAME="Titelseite_NAK_Text" LOCALSCX="1" LOCALSCY="1" LOCALX="0" LOCALY="0" LOCALROT="0" PICART="1" SCALETYPE="1" RATIO="1" COLUMNS="1" COLGAP="0" AUTOTEXT="0" EXTRA="0" TEXTRA="0" BEXTRA="0" REXTRA="0" VAlign="2" FLOP="0" PLTSHOW="0" BASEOF="0" textPathType="0" textPathFlipped="0" path="M0 0 L187.087 0 L187.087 28.3465 L0 28.3465 L0 0 Z" copath="M0 0 L187.087 0 L187.087 28.3465 L0 28.3465 L0 0 Z" gXpos="-0.988188976378382" gYpos="17.0078740157479" gWidth="242.791338582672" gHeight="45.3543307086615" LAYER="0" NEXTITEM="-1" BACKITEM="-1">
//<StoryText>
//<DefaultStyle/>
//<ITEXT FONTSIZE="12" CH="Neuapostolische Kirche"/>
//<para PARENT="NAK"/>
//<ITEXT FONTSIZE="12" CH="Nord- und Ostdeutschland"/>
//<trail PARENT="Nord- und Ostdeutschland"/>
//</StoryText>
//</PAGEOBJECT>*/
//  }
//}