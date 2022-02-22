//<?php
//require __DIR__ . '/libs/vendor/autoload.php';

///* if (php_sapi_name() != 'cli') {
//throw new Exception('This application must be run on the command line.');
//} */

///**
// * Returns an authorized API client.
// * @return Google_Client the authorized client object
// */

//function ersetzen($String) {
//  $String = str_replace('ö', 'oe', $String);
//  $String = str_replace('Ö', 'Oe', $String);
//  $String = str_replace('ä', 'ae', $String);
//  $String = str_replace('Ä', 'Ae', $String);
//  $String = str_replace('ü', 'ue', $String);
//  $String = str_replace('Ü', 'Ue', $String);
//  $String = str_replace('ß', 'ss', $String);
//  return $String;
//}

//function getClient() {
//  $client = new Google_Client();
//  $client->setApplicationName('Google Calendar API PHP Quickstart');
//  $client->setScopes(Google_Service_Calendar::CALENDAR_READONLY);
//  $client->setAuthConfig('credentials.json');
//  $client->setAccessType('offline');
//  $client->setPrompt('select_account consent');

//  // Load previously authorized token from a file, if it exists.
//  // The file token.json stores the user's access and refresh tokens, and is
//  // created automatically when the authorization flow completes for the first
//  // time.
//  $tokenPath = 'token.json';
//  if (file_exists($tokenPath)) {
//    $accessToken = json_decode(file_get_contents($tokenPath), true);
//    $client->setAccessToken($accessToken);
//  }

//  // If there is no previous token or it's expired.
//  if ($client->isAccessTokenExpired()) {
//    // Refresh the token if possible, else fetch a new one.
//    if ($client->getRefreshToken()) {
//      $client->fetchAccessTokenWithRefreshToken($client->getRefreshToken());
//    } else {
//      // Request authorization from the user.
//      $authUrl = $client->createAuthUrl();
//      printf("Open the following link in your browser:\n%s\n", $authUrl);
//      print 'Enter verification code: ';
//      $authCode = trim(fgets(STDIN));

//      // Exchange authorization code for an access token.
//      $accessToken = $client->fetchAccessTokenWithAuthCode($authCode);
//      $client->setAccessToken($accessToken);

//      // Check to see if there was an error.
//      if (array_key_exists('error', $accessToken)) {
//        throw new Exception(join(', ', $accessToken));
//      }
//    }
//    // Save the token to a file.
//    if (!file_exists(dirname($tokenPath))) {
//      mkdir(dirname($tokenPath), 0700, true);
//    }
//    file_put_contents($tokenPath, json_encode($client->getAccessToken()));
//  }
//  return $client;
//}

//// Get the API client and construct the service object.
//$client = getClient();
//$service = new Google_Service_Calendar($client);

//// Print the next 10 events on the user's calendar.
//$calendarId = '34m2qp8sbhshkdpj1dco8sdbe0@group.calendar.google.com';
//$optParams = array(
//  'maxResults' => 3,
//  'orderBy' => 'startTime',
//  'singleEvents' => true,
//  'timeMin' => date('c'),
//);
//$results = $service->events->listEvents($calendarId, $optParams);
//$events = $results->getItems();

////$lstrHTML = '<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html lang="de" xml:lang="en" xmlns="http://www.w3.org/1999/xhtml"><head><meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" /><title></title><style type="text/css">html,body{background-color:#fff;color:#333;line-height:1.4;font-family:sans-serif,Arial,Verdana,Trebuchet MS;}</style></head><body>';
//$lstrHTML = '';
//if (!empty($events)) {
//  $lintCounter = 1;
//  $lstrHTML .= '<h1>Nächste Dienste</h1>';
//  foreach ($events as $event) {
//    $start = $event->start->dateTime;
//    if (empty($start)) {
//      $start = $event->start->date;
//    }
//    $larrSize = array('<h2>', '</h2>');
//    if ($lintCounter == 2) {
//      $larrSize = array('<h3>', '</h3>');
//    }
//    if ($lintCounter == 3) {
//      $larrSize = array('<h4>', '</h4>');
//    }
//    $lstrHTML .= $larrSize[0].'<b>' . date('d.m.Y - H:i', strtotime($start)) . '</b> - <i>' . html_entity_decode($event->getSummary()) . '</i>' . $larrSize[1];
//    //printf("%s (%s)\n", $event->getSummary(), $start);
//    $lintCounter++;
//  }
//}
////$lstrHTML .= '</body></html>';

////$lstrHTML = htmlspecialchars_decode($lstrHTML);
////$lstrHTML = html_entity_decode($lstrHTML);

//echo $lstrHTML;

//use PHPMailer\PHPMailer\PHPMailer;
//use PHPMailer\PHPMailer\Exception;

//require './libs/vendor/phpmailer/phpmailer/src/Exception.php';
//require './libs/vendor/phpmailer/phpmailer/src/PHPMailer.php';
//require './libs/vendor/phpmailer/phpmailer/src/SMTP.php';

//$mail = new PHPMailer(); // Passing `true` enables exceptions
//try {
//  //Server settings
//  $mail->SMTPDebug = 1; // Enable verbose debug output
//  $mail->Encoding = 'base64';
//  $mail->CharSet = 'UTF-8';
//  $mail->isSMTP(); // Set mailer to use SMTP
//  $mail->Host = 'w0131b0c.kasserver.com'; // Specify main and backup SMTP servers
//  $mail->SMTPAuth = true; // Enable SMTP authentication
//  $mail->Username = 'm04c2500'; // SMTP username
//  $mail->Password = 'Nak123!NH'; // SMTP password
//  $mail->SMTPSecure = 'tls'; // Enable TLS encryption, `ssl` also accepted
//  $mail->Port = 587; // TCP port to connect to

//  //Recipients
//  $mail->setFrom('erinnerung@nak-nordheide.de', 'Erinnerung');

//  $mail->addAddress('kirche@familie-koester.eu', 'Diakone');

//  //Content
//  $mail->isHTML(true); // Set email format to HTML
//  $mail->Subject = 'Infos Diakondienst';
//  $mail->Body = $lstrHTML;

//  $mail->send();
  
//  echo ('Gesendet');
//} catch (Exception $e) {
//  return 'Message could not be sent. Mailer Error: ' . $mail->ErrorInfo;
//}