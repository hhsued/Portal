//<?php

//namespace controller;

//include_once './app/helper/strings.php';
//use \app\helper\strings as strings;
//class ical
//{
//  private $carrSavedAppointments;
//  public function __construct()
//  {
//  }

//  public function get($Filter = null)
//  {
//    global $app;
//    $lstrQuery = "SELECT * FROM sched_Appointment ";

//    if (gettype($Filter) == 'string' && $Filter != 'json') {
//      $lstrQuery .= "WHERE CATEGORIES = '" . $Filter . "'";
//    } elseif (gettype($Filter) == 'array') {
//      $lstrQuery .= "WHERE ";
//      foreach ($Filter as $lstrFilterEntry) {
//        $lstrQuery .= "CATEGORIES = '" . $lstrFilterEntry . "' OR ";
//      }
//      $lstrQuery = substr($lstrQuery, 0, strlen($lstrQuery) - 4);
//    }

//    $lstrQuery .= " ORDER BY DTSTART, CATEGORIES";
//    return $app->DB->execute($lstrQuery);
//  }

//  public function read()
//  {
//    global $app;
      
//    if ($this->getFiles()) {
//      $larrNewAppointments = $app->DB->get('sched_Appointments', array('status_type' => 'creation', 'status_status' => 'approved'));
//      $larrDeletedAppointments = $app->DB->get('sched_Appointments', array('status_type' => 'deletion', 'status_status' => 'approved'));
//      $larrChangedAppointments = $app->DB->get('sched_Appointments', array('status_type' => 'change', 'status_status' => 'approved'));      

//      $app->DB->empty('sched_Appointments');
//      $this->parse();

//      foreach ($larrNewAppointments as $larrApointment) {
//        unset($larrApointment['id']);
//        $app->DB->insert('sched_Appointments',$larrApointment);
//      }
//    }
//  }
//  private function cleanUpDatabase() {

//  }
//  private function parse()
//  {
//    global $app;
//    // Get Appointments from Files
//    $larrFiles = array(
//      "Bezirk" => array("File" => "Bezirk%20HH-Sued.ics", "Bezirk" => true, "Category" => "Bezirk"),
//      "Buxtehude" => array("File" => "GBux.ics", "Category" => "Gemeinde Bux"),
//      "Harburg" => array("File" => "GHar.ics", "Category" => "Gemeinde Har"),
//      "Neugraben" => array("File" => "GNeu.ics", "Category" => "Gemeinde Neu"),
//      "Sinstorf" => array("File" => "GSin.ics", "Category" => "Gemeinde Sin"),
//      "Nordheide" => array("File" => "GNor.ics", "Category" => "Gemeinde Nor"),
//      "Rotenburg" => array("File" => "GRoW.ics", "Category" => "Gemeinde RoW"),
//      "Winsen" => array("File" => "GWin.ics", "Category" => "Gemeinde Win"),
//    );

//    foreach($larrFiles as $larrFile) {
//      $this->readFile($larrFile);
//    }
//  }  
//  private function deleteDatasetsInArray($Array, $Type)
//  {
//    $larrTemp = array();
//    switch ($Type) {
//      case 'key_based':
//        foreach($Array as $lstrSingleValue) {
//          if (!isset($Array[$lstrSingleValue['UID']]['delete'])) {
//            $larrTemp[$lstrSingleValue] = $Array[$lstrSingleValue];
//          }
//        }

//      break;
//      case 'index_based':
//        for ($lintArrayCounter = 0; $lintArrayCounter < count($Array); $lintArrayCounter++) {
//          if (!isset($Array[$lintArrayCounter]['delete'])) {
//            array_push($larrTemp, $Array[$lintArrayCounter]);
//          }
//        }        
//      break;
//    }
//    return $larrTemp;
//  }
//  private function findDifferences($DBAppointment, $FileAppointment)
//  {
//    $lintDifferences = 0;

//    if ($DBAppointment['location'] != $FileAppointment['LOCATION']) $lintDifferences++;
//    if ($DBAppointment['summary'] != $FileAppointment['SUMMARY']) $lintDifferences++;
//    if ($DBAppointment['description'] == "" && $FileAppointment['DESCRIPTION'] == "") $lintDifferences++;
//    if ($DBAppointment['description'] != $FileAppointment['DESCRIPTION']) $lintDifferences++;
//    if ($DBAppointment['dtstart'] != date('Y-m-d H:i:s', strtotime($FileAppointment['DTSTART']))) $lintDifferences++;
//    if ($DBAppointment['dtend'] != date('Y-m-d H:i:s', strtotime($FileAppointment['DTEND']))) $lintDifferences++;
//    if ($DBAppointment['categories'] != $FileAppointment['CATEGORIES']) $lintDifferences++;

//    if ($lintDifferences == 1 && $DBAppointment['description'] == "" && $FileAppointment['DESCRIPTION'] == "") {
//      $lintDifferences--;
//    }

//    return $lintDifferences;
//  }

//  private function readFile($File) {
//    // Alle Daten löschen außer denen, die noch nicht gesendet wurden!

//    $lstrFile = 'http://www.menne.biz/NAK/' . $File['File'];
//    //$File = 'http://e.hh-sued.de/testdaten/' . $FileData['File'];
//    $lstrFileContent = file_get_contents($lstrFile);

//    $lstrFileContent = str_replace("\xEF\xBB\xBF", '', $lstrFileContent);

//    $bom = pack('H*', 'EFBBBF');
//    $lstrFileContent = preg_replace("/^$bom/", '', $lstrFileContent);

//    preg_match_all('/(BEGIN:VEVENT.*?END:VEVENT)/si', $lstrFileContent, $larrAppointments, PREG_PATTERN_ORDER);
//    for ($lintAppointmentCounter = 0; $lintAppointmentCounter < count($larrAppointments[0]); $lintAppointmentCounter++) {
//      $larrAppointment = explode("rn", $larrAppointments[0][$lintAppointmentCounter]);
//      $lstrAppointment = $larrAppointment[0];
//      unset($larrAppointment);
//      $lstrAppointment = ltrim(str_replace('BEGIN:VEVENT', '', $lstrAppointment));
//      $lstrAppointment = rtrim(str_replace('END:VEVENT', '', $lstrAppointment));
//      $lstrAppointment = rtrim(str_replace('CLASS:PUBLIC', '', $lstrAppointment));

//      preg_match_all('/[A-Z]*:/', $lstrAppointment, $larrAppointmentKeys);

//      $larrAppointmentValues = preg_split('/[A-Z]*:/', $lstrAppointment);
//      unset($lstrAppointment);
//      if ($larrAppointmentValues[0] == '') {
//        array_shift($larrAppointmentValues);
//      }

//      $larrAppointmentKeys = $larrAppointmentKeys[0];
//      $larrAppointment = array();

//      for ($lintKeysCounter = 0; $lintKeysCounter < count($larrAppointmentKeys); $lintKeysCounter++) {
//        $lstrKey = $larrAppointmentKeys[$lintKeysCounter];
//        $lstrValue = $larrAppointmentValues[$lintKeysCounter];
//        if (substr($lstrKey, strlen($lstrKey) - 1) == ':') {
//          $lstrKey = substr($lstrKey, 0, strlen($lstrKey) - 1);
//        }
//        $larrAppointment[$lstrKey] = rtrim($lstrValue);
//        $larrAppointment[$lstrKey] = ltrim($larrAppointment[$lstrKey]);
//      }
//      if (isset($larrAppointment['CATEGORIES'])) {
//        if (isset($File['Bezirk']) || strpos($larrAppointment['CATEGORIES'], $File['Category']) > -1) {
//          if (array_key_exists('DTSTART', $larrAppointment)) {
//            if (strtotime($larrAppointment['DTSTART']) >= time()) {
//              $larrAppointment['CATEGORIES'] = (strstr($larrAppointment['CATEGORIES'], "\r\nLAST-")) ? str_replace("\r\nLAST-", '', $larrAppointment['CATEGORIES']) : $larrAppointment['CATEGORIES'];
//              $this->DatabaseOperation($larrAppointment,'insert');
//            }
//          }
//        }
//      }
//    }
//  }
//  private function DatabaseOperation($Appointment, $Type = 'insert')
//  {
//    global $app;
//    $lstrVersion = 1;
//    if (strtolower($Type) == 'update') {
//      $lstrVersion = $app->DB->newVersion("sched_Appointments", $Appointment['id']);
//    }
//    $larrData = array();
//    isset($Appointment['UID']) ? $larrData["uid"] =  $Appointment['UID']: "";
//    isset($Appointment['LOCATION']) ? $larrData["location"] =  $Appointment['LOCATION'] : "";
//    isset($Appointment['SUMMARY']) ? $larrData["summary"] =  $Appointment['SUMMARY'] : "";
//    isset($Appointment['DESCRIPTION']) ? $larrData["description"] =  $Appointment['DESCRIPTION'] : "";
//    isset($Appointment['CLASS']) ? $larrData["class"] = $Appointment['CLASS'] : "";
//    isset($Appointment['DTSTART']) ? $larrData["dtstart"] = date('Y-m-d H:i:s', strtotime($Appointment['DTSTART'])) : "";
//    isset($Appointment['DTEND']) ? $larrData["dtend"] = date('Y-m-d H:i:s', strtotime($Appointment['DTEND'])) : "";
//    isset($Appointment['DTSTAMP']) ? $larrData["dtstamp"] =  date('Y-m-d H:i:s', strtotime($Appointment['DTSTAMP'])) : "";
//    isset($Appointment['CATEGORIES']) ? $larrData["categories"] =  $Appointment['CATEGORIES'] : "";
//    isset($Appointment['MODIFIED']) ? $larrData["last_modified"] =  date('Y-m-d H:i:s', strtotime($Appointment['MODIFIED'])) : "";

//    $larrData['status_type'] = 'transmission';
//    $larrData['status_status'] = 'success';
//    $app->DB->set('sched_Appointments', $larrData);
//  }

//  private function getFiles()
//  {
//    global $app;

//    $larrHeaders = get_headers('http://www.menne.biz/NAK/Bezirk%20HH-Sued.ics', 1);

//    if (strstr($larrHeaders[0], '200') != false) {
//      $lstrETag = '"' . $app->Config->get('reader:eTag', 'iCal') . '"';
//      if ($lstrETag != $larrHeaders['ETag']) {
//        $app->Config->set('reader:eTag', str_replace("\"", "", $larrHeaders['ETag']), 'iCal');
//        return true;
//      } else {
//        return false;
//      }
//    }
//  }
//}