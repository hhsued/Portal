//<?php

//namespace controller;

//use PHPMailer\PHPMailer\PHPMailer;
//use PHPMailer\PHPMailer\Exception;

//class newsletter
//{
//    private $config;

//    function __construct()
//    {
//        $this->config = include_once('./config/newsletter.php');
//    }
//    function newItem($data)
//    {
//        global $app;
//        $lstrQuery = '';
//        switch ($data[0]) {
//            case 'editors':
//                $lstrQuery = 'INSERT INTO nl_editors (firstname, lastname, email, code) VALUES ("Bitte pflegen","Bitte pflegen","Bitte pflegen","Bitte pflegen")';
//                break;
//            case 'receivers':
//                $lstrQuery = 'INSERT INTO nl_receivers (email_address, active, shortcut) VALUES ("Bitte pflegen",1,"Bitte pflegen")';
//                break;
//            case 'lists':
//                $lstrQuery = 'INSERT INTO nl_lists (listname, active) VALUES ("Bitte pflegen",1)';
//                break;
//            case 'types':
//                $lstrQuery = 'INSERT INTO nl_types (name, active) VALUES ("Bitte pflegen",1)';
//                break;
//        }
//        return $app->DB->exec($lstrQuery);
//    }
//    function deleteItem($data)
//    {
//        global $app;
//        $lstrQuery = 'DELETE FROM nl_' . $data[0] . ' WHERE id = ' . $data['id'];
//        return $app->DB->exec($lstrQuery);
//    }
//    function getItems($data)
//    {
//        global $app;
//        $lstrQuery = 'SELECT * FROM nl_' . $data[0];
//        return $app->DB->exec($lstrQuery);
//    }
//    function saveItem($data)
//    {
//        global $app;
//        $lintID = $data['id'];
//        $lstrType = $data[0];
//        $lstrLists = '';
//        if (isset($data['lists'])) {
//            $lstrLists = $data['lists'];
//        }
//        $lstrQuery = 'UPDATE nl_' . $lstrType . ' SET ';
//        unset($data[0], $data['acc'], $data['id'], $data['lists']);

//        foreach (array_keys($data) as $lstrKey) {
//            $lstrQuery .= $lstrKey . '="' . $data[$lstrKey] . '",';
//        }

//        $lstrQuery = substr($lstrQuery, 0, strlen($lstrQuery) - 1);
//        $lstrQuery .= ' WHERE id = ' . $lintID;
//        $app->DB->exec($lstrQuery);

//        if ($lstrType == 'receivers') {
//            $lstrQuery = "DELETE FROM nl_mapping_list_receivers WHERE receiver_id = " . $lintID;
//            $app->DB->exec($lstrQuery);
//            $larrIDs = explode(",", $lstrLists);
//            foreach ($larrIDs as $lstrID) {
//                $lstrQuery = 'INSERT INTO nl_mapping_list_receivers (list_id, receiver_id) VALUES (' . $lstrID . ',' . $lintID . ')';
//                $app->DB->exec($lstrQuery);
//            }
//        }
//    }
//    function saveData($data)
//    {
//        global $app;
//        $lstrQuery = 'UPDATE nl_newsletter SET name="' . $data['name'] . '", configuration="' . addslashes(json_encode($data['configuration'])) . '", lists="' . $data['lists'] . '" WHERE id = ' . $data['id'];
//        $app->DB->exec($lstrQuery);
//    }
//    function sendNewsletterAppointmentsTemplate($Configuration, $List, $UserID, $NewsletterID)
//    {
//        $Configuration = json_decode($Configuration, true);
//        $lstrTemplate = file_get_contents("./data/newsletter/templates/schedules.html");
//        $lstrTemplate = str_replace("##WATCH_IN_BROWSER##", $this->config['url'] . $this->config['watch_in_browser'] . '/' . $NewsletterID, $lstrTemplate);
//        $lstrTemplate = str_replace("##YEAR##", $Configuration['version']['year'], $lstrTemplate);
//        $lstrTemplate = str_replace("##MONTH##", $Configuration['version']['month'], $lstrTemplate);
//        $lstrTemplate = str_replace("##VERSION##", $Configuration['version']['version'], $lstrTemplate);
//        $lstrTemplate = str_replace("##MAIL##", $this->config['reply_email'], $lstrTemplate);

//        $lstrTemplate = str_replace(
//            "##UNSUBSCRIBE##",
//            $this->config['url'] . $this->config['unsubscribe'] . '/' . $UserID . "/" . $List,
//            $lstrTemplate
//        );

//        return $lstrTemplate;
//    }
//    function sendNewsletter($data)
//    {
//        global $app;
//        $larrAttachments = array();

//        $lstrQuery = 'SELECT * FROM nl_newsletter WHERE id = ' . $data['id'];
//        $larrData = $app->DB->exec($lstrQuery);
//        $lstrQuery = 'SELECT * FROM nl_attachments WHERE newsletter_id = ' . $data['id'];
//        $larrAttachmentData = $app->DB->exec($lstrQuery);

//        if (count($larrAttachmentData) > 0) {
//            foreach ($larrAttachmentData as $larrAttachment) {
//                array_push($larrAttachments, "./data/newsletter/attachments/" . $larrAttachment['folder'] . "/" . $larrAttachment['name']);
//            }
//        }

//        if ($larrData[0]['lists'] == null) {
//            return "noReceivers";
//        } else {
//            $lstrBody = "";

//            if (strpos($larrData[0]['lists'], ',') > 0) {
//            } else {
//                $larrUserIDs = $this->getReceivers($larrData[0]['lists']);
//                for ($lintCounter = 0; $lintCounter < count($larrUserIDs); $lintCounter++) {
//                    $lstrQuery = 'SELECT * FROM nl_receivers WHERE id = ' . $larrUserIDs[$lintCounter]['receiver_id'];
//                    $larrUserData = $app->DB->exec($lstrQuery);

//                    switch ($larrData[0]['type']) {
//                        case '1':
//                            $lstrBody = $this->sendNewsletterAppointmentsTemplate($larrData[0]['configuration'], $larrData[0]['lists'], $larrUserData[0]['shortcut'], $data['id']);
//                            break;
//                    }

//                    $this->sendEMail(
//                        array($this->config['sender_email'], $this->config['sender_name']),
//                        array($larrUserData[0]['email_address'], ''),
//                        array($this->config['reply_email'], $this->config['reply_name']),
//                        $larrData[0]['name'],
//                        $lstrBody,
//                        $larrAttachments
//                    );
//                }
//            }
//        }
//        $lstrQuery = 'UPDATE nl_newsletter SET last = "' . date("Y-m-d H:i:s") . '" WHERE id = ' . $data['id'];
//        $app->DB->exec($lstrQuery);
//    }

//    function getReceivers($List)
//    {
//        global $app;
//        $lstrQuery = 'SELECT * FROM nl_mapping_list_receivers WHERE list_id = ' . $List;
//        return $app->DB->exec($lstrQuery);
//    }
//    function unsubscribe($data)
//    {
//        global $app;
//        $lstrQuery =
//            'DELETE FROM nl_mapping_list_receivers WHERE receiver_id = (SELECT id FROM nl_receivers WHERE shortcut = "' . $data['user'] . '") AND list_id = ' . $data['list'];
//        $app->DB->exec($lstrQuery);
//    }
//    function getListData($data)
//    {
//        global $app;
//        $lstrQuery = 'SELECT * FROM nl_lists WHERE id = ' . $data['id'];
//        return $app->DB->exec($lstrQuery);
//    }
//    function uploadAttachments($data)
//    {
//        global $app;
//        $lstrQuery = 'SELECT created FROM nl_newsletter WHERE id = ' . $data[0];
//        $larrReturnValues = $app->DB->exec($lstrQuery);
//        $larrReturnValues[0]['created'];
//        $lstrFolder = $this->cleanDate($larrReturnValues[0]['created']);
//        move_uploaded_file($_FILES['undefined']['tmp_name'], "./data/newsletter/attachments/" . $lstrFolder . "/" . $_FILES['undefined']['name']);
//        $lstrQuery = 'INSERT INTO nl_attachments (name, folder, newsletter_id) VALUES ("' . $_FILES['undefined']['name'] . '","' . $lstrFolder . '","' . $data[0] . '")';
//        $app->DB->exec($lstrQuery);
//        return var_dump($_FILES);
//    }
//    function cleanDate($Date)
//    {
//        $Date = str_replace("-", "", $Date);
//        $Date = str_replace(":", "", $Date);
//        $Date = str_replace(" ", "", $Date);
//        return $Date;
//    }
//    function deleteAttachment($data)
//    {
//        global $app;
//        $lstrQuery = 'DELETE FROM nl_attachments WHERE id = ' . $data['id'];
//        $app->DB->exec($lstrQuery);
//        unlink("./data/newsletter/" . $data['folder'] . "/" . $data['name']);
//    }
//    function getAttachments($data)
//    {
//        global $app;
//        $lstrQuery = "";

//        if (isset($data['id'])) {
//            $lstrQuery = 'SELECT * FROM nl_attachments WHERE newsletter_id = ' . $data['id'];
//        } else {
//            $lstrQuery = 'SELECT * FROM nl_attachments WHERE newsletter_id = ' . $data[0];
//        }

//        return
//            $app->DB->exec($lstrQuery);
//    }
//    function getUserData($data)
//    {
//        global $app;
//        $lstrQuery = 'SELECT * FROM nl_receivers WHERE shortcut = "' . $data['shortcut'] . '"';
//        return
//            $app->DB->exec($lstrQuery);
//    }
//    function getNewsletterData($data)
//    {
//        global $app;
//        $lstrQuery = 'SELECT * FROM nl_newsletter WHERE id = ' . $data[0];
//        return
//            $app->DB->exec($lstrQuery);
//    }
//    function getLists($data)
//    {
//        global $app;
//        $lstrQuery = 'SELECT * FROM nl_lists WHERE active = 1';
//        return
//            $app->DB->exec($lstrQuery);
//    }
//    function deleteNewsletter($data)
//    {
//        global $app;
//        $lstrQuery = 'DELETE FROM nl_newsletter WHERE id = ' . $data['id'];
//        return
//            $app->DB->exec($lstrQuery);
//    }
//    function checkUser($data)
//    {
//        global $app;

//        $lstrQuery = 'SELECT * FROM nl_editors WHERE code = "' . $data['code'] . '"';
//        $lobjResult = $app->DB->exec($lstrQuery);
//        if (!is_null($lobjResult)) {
//            return 'ok';
//        } else {
//            return 'unknownUser';
//        }
//    }
//    function copyNewsletter($data)
//    {
//        global $app;

//        $lstrQuery = 'SELECT * FROM nl_newsletter WHERE id = ' . $data['id'];
//        $lobjResult = $app->DB->exec($lstrQuery);

//        $lstrDate = date("Y-m-d H:i:s");

//        mkdir("./data/newsletter/attachments/" . $this->cleanDate($lstrDate));

//        $lstrQuery = 'INSERT INTO nl_newsletter (name, status, type, created, last, configuration, lists) VALUES ("' . $lobjResult[0]['name'] . '-Kopie' . '", "erstellt", ' . $lobjResult[0]['type'] . ',"' . $lstrDate . '","0000-00-00 00:00:00","' . addslashes($lobjResult[0]['configuration']) . '","' . $lobjResult[0]['lists'] . '")';
//        return
//            $app->DB->exec($lstrQuery);
//    }
//    function createNewNewsletter($data)
//    {
//        global $app;
//        $lstrConfig = "";

//        $lstrDate = date("Y-m-d H:i:s");

//        mkdir("./data/newsletter/attachments/" . $this->cleanDate($lstrDate));
//        if ($data["type"] == "1") {
//            $lstrConfig = "{\"version\":{\"year\":2021,\"month\":1,\"version\":1}}";
//        }
//        $lstrQuery = 'INSERT INTO nl_newsletter (name, status, type, created, last, configuration, lists) VALUES ("' . $data['name'] . '", "erstellt", ' . $data['type'] . ',"' . $lstrDate . '","0000-00-00 00:00:00","' . addslashes($lstrConfig) . '","1")';
//        return
//            $app->DB->exec($lstrQuery);
//    }
//    function getNewsletter($data)
//    {
//        global $app;
//        $lstrQuery = "";

//        if (isset($data['id'])) {
//            $lstrQuery = 'SELECT * FROM nl_newsletter WHERE id = ' . $data['id'];
//        } else {
//            $lstrQuery = 'SELECT nl_newsletter.id, nl_newsletter.name, nl_newsletter.status, nl_types.name AS type, DATE_FORMAT(nl_newsletter.created, "%d.%m.%Y - %H:%i:%s" ) AS created , DATE_FORMAT(nl_newsletter.last, "%d.%m.%Y - %H:%i:%s") AS last FROM nl_newsletter, nl_types WHERE nl_newsletter.`type` = nl_types.id';
//        }
//        return
//            $app->DB->exec($lstrQuery);
//    }
//    function getNewsletterTypes($data)
//    {
//        global $app;
//        $lstrQuery = 'SELECT * FROM nl_types WHERE active = 1';
//        return
//            $app->DB->exec($lstrQuery);
//    }
//    function verify($data)
//    {
//        global $app;
//        $lstrQuery = 'SELECT * FROM nl_receivers WHERE verify_code = "' . $data['verifyCode'] . '"';
//        $lobResult = $app->DB->exec($lstrQuery);
//        if (count($lobResult) > 0) {
//            if ((int)$lobResult[0]['code_gets_invalid'] > time()) {
//                $lstrQuery = 'UPDATE nl_receivers SET active = "1", verify_code = "", code_gets_invalid = "", verified_on = "' . time() . '" WHERE verify_code = "' . $data['verifyCode'] . '"';
//                $app->DB->exec($lstrQuery);

//                $body = file_get_contents("./data/newsletter/templates/successfullyRegistered.html");

//                $From = array($this->config['sender_email'], $this->config['sender_name']);
//                $To = array($lobResult[0]['email_address'], '');
//                $Reply = array($this->config['reply_email'], $this->config['reply_name']);

//                $body = str_replace("###ADDRESS###", $this->config['url'] . $this->config['edit'] . '/' . $lobResult[0]['shortcut'], $body);
//                $body = str_replace("##MAIL##", $this->config['reply_email'], $body);

//                $Subject = "Bezirk Hamburg-Süd: Erfolgreich registriert";

//                $this->sendEMail($From, $To, $Reply, $Subject, $body, array());
//                return "successfull";
//            } else {
//                $lstrCode = $this->generateVerifyCode();
//                $lstrQuery = 'UPDATE nl_receivers SET active = "0", verify_code = "' . $lstrCode . '", code_gets_invalid = "' . $this->generateInvalidDate() . '" WHERE email_address = "' . $data['email'] . '"';
//                $app->DB->exec($lstrQuery);

//                $this->newSubscriberMail($data, $lstrCode);
//                return "codeOutdatet";
//            }
//        } else {
//            return "codeNotFound";
//        }
//    }
//    private function generateVerifyCode()
//    {
//        $lstrCode = microtime();
//        $lstrCode = str_replace(" ", "", $lstrCode);
//        $lstrCode = str_replace(".", "", $lstrCode);
//        return $lstrCode;
//    }
//    private function generateInvalidDate()
//    {
//        return
//            time() + (1 * 24 * 60 * 60);
//    }
//    private function sendEMail($From, $To, $Reply, $Subject, $Body, $Attachments)
//    {
//        require 'libs/vendor/autoload.php';

//        $mail = new PHPMailer();                              // Passing `true` enables exceptions
//        try {
//            //Server settings
//            $mail->SMTPDebug = 0;
//            $mail->CharSet = 'utf-8';
//            $mail->isSMTP();                                      // Set mailer to use SMTP
//            $mail->Host = 'w0131afa.kasserver.com';  // Specify main and backup SMTP servers
//            $mail->SMTPAuth = true;                               // Enable SMTP authentication
//            $mail->Username = 'm04adf11';                 // SMTP username
//            $mail->Password = 'Nak123!SMTP';                           // SMTP password
//            $mail->SMTPSecure = 'tls';                            // Enable TLS encryption, `ssl` also acceptedx
//            $mail->Port = 587;                                    // TCP port to connect to

//            //Recipients
//            $mail->setFrom($From[0], $From[1]);

//            $mail->addAddress($To[0], $To[1]);
//            $mail->addReplyTo($Reply[0], $Reply[1]);

//            //Attachments
//            if (count($Attachments) > 0) {
//                foreach ($Attachments as $lstrAttachment) {
//                    $mail->addAttachment($lstrAttachment);
//                }
//            }

//            //Content
//            $mail->isHTML(true);                                  // Set email format to HTML
//            $mail->Subject = $Subject;
//            $mail->Body    = $Body;

//            $mail->send();
//        } catch (Exception $e) {
//            return 'Message could not be sent. Mailer Error: ' . $mail->ErrorInfo;
//        }
//    }
//    function deleteAccount($data)
//    {
//        global $app;
//        $lstrQuery = 'DELETE FROM nl_mapping_list_receivers WHERE receiver_id = ' . $data['id'];
//        $app->DB->exec($lstrQuery);
//        $lstrQuery = 'DELETE FROM nl_receivers WHERE id = ' . $data['id'];
//        $app->DB->exec($lstrQuery);
//    }
//    function activateAccount($data)
//    {
//        global $app;
//        $lstrQuery = 'UPDATE nl_receivers SET active = 1 WHERE id = ' . $data['id'];
//        $app->DB->exec($lstrQuery);
//    }
//    function deactivateAccount($data)
//    {
//        global $app;
//        $lstrQuery = 'UPDATE nl_receivers SET active = 0 WHERE id = ' . $data['id'];
//        $app->DB->exec($lstrQuery);
//    }
//    function saveUserData($data)
//    {
//        global $app;
//        $lstrQuery = 'UPDATE nl_receivers SET email_address = "' . $data['email'] . '" WHERE id = ' . $data['id'];
//        $app->DB->exec($lstrQuery);
//        $lstrQuery = 'DELETE FROM nl_mapping_list_receivers WHERE receiver_id = ' . $data['id'];
//        $app->DB->exec($lstrQuery);
//        foreach ($data['lists'] as $lintListID) {
//            $lstrQuery = 'INSERT INTO nl_mapping_list_receivers (list_id, receiver_id) VALUES (' . $lintListID . ',' . $data['id'] . ')';
//            $app->DB->exec($lstrQuery);
//        }
//    }
//    function getListsOfUser($data)
//    {
//        global $app;
//        $lstrQuery = 'SELECT list_id FROM nl_mapping_list_receivers WHERE receiver_id = "' . $data['userID'] . '"';
//        $lobjResponse = $app->DB->exec($lstrQuery);
//        $larrResults = array();
//        if (!is_null($lobjResponse) && count($lobjResponse) > 0) {
//            foreach ($lobjResponse as $lobjElement) {
//                array_push($larrResults, $lobjElement['list_id']);
//            }
//        }
//        return $larrResults;
//    }
//    private function checkListsForUser($lintUser, $lists)
//    {
//        global $app;
//        foreach ($lists as $lintList) {
//            $lstrQuery = 'SELECT * FROM nl_mapping_list_receivers WHERE list_id = "' . $lintList . '" AND receiver_id = "' . $lintUser . '"';
//            $lintID = $app->DB->exec($lstrQuery, 'id');
//            if (is_null($lintID)) {
//                $lstrQuery = 'INSERT INTO nl_mapping_list_receivers (list_id, receiver_id) VALUES ("' . $lintList . '","' . $lintUser . '")';
//                $app->DB->exec($lstrQuery);
//            }
//        }
//    }
//    function getTexts($Type)
//    {
//        switch ($Type) {
//            case "registration":
//                include_once "./data/newsletter/texts/verify_registration.php";
//                break;
//            case "verified":
//                include_once "./data/newsletter/texts/registration_successfully.php";
//                break;
//        }
//    }

//    function newSubscriberMail($Data, $Code)
//    {
//        $body = file_get_contents("./data/newsletter/templates/newSubscriber.html");

//        $From = array($this->config['sender_email'], $this->config['sender_name']);
//        $To = array($Data['email'], '');
//        $Reply = array($this->config['reply_email'], $this->config['reply_name']);

//        $Subject = 'Bezirk Hamburg-Süd: Registrierung für Rundschreiben';
//        $body = str_replace("###ADDRESS###", $this->config['url'] . $this->config['verify'] . '/' . $Code, $body);
//        $body = str_replace("##MAIL##", $this->config['reply_email'], $body);

//        $this->sendEMail($From, $To, $Reply, $Subject, $body, array());
//    }

//    function newSubscriber($data)
//    {
//        global $app;
//        $lstrQuery = 'SELECT * FROM nl_receivers WHERE email_address = "' . $data['email'] . '"';
//        $lobResult = $app->DB->exec($lstrQuery);
//        $lstrCode = $this->generateVerifyCode();

//        if (!is_null($lobResult)) {
//            if ($lobResult[0]['active'] == '1') {
//                // Gebe zurück, dass es schon eine aktive E-Mail gibt, prüfe aber die zugehörigen Listen
//                // TODO
//                $this->checkListsForUser($lobResult[0]['id'], $data['lists']);
//                return "activeFound";
//            }
//            if ($lobResult[0]['active'] == '0') {

//                $lstrQuery = 'UPDATE nl_receivers SET active = "0", verify_code = "' . $lstrCode . '", code_gets_invalid = "' . $this->generateInvalidDate() . '" WHERE email_address = "' . $data['email'] . '"';
//                $app->DB->exec($lstrQuery);
//                $this->newSubscriberMail($data, $lstrCode);
//                return "existedNotActive";
//            }
//        } else {
//            $lstrQuery = 'INSERT INTO nl_receivers (email_address, active, verify_code, code_gets_invalid, verified_on, shortcut) VALUES ("' . $data['email'] . '","0","' . $lstrCode . '","' . $this->generateInvalidDate() . '","","' . $lstrCode . '")';
//            $lintID = $app->DB->exec($lstrQuery, 'id');
//            $this->newSubscriberMail($data, $lstrCode);
//            foreach ($data['lists'] as $lstrList) {
//                $lstrQuery = 'INSERT INTO nl_mapping_list_receivers (list_id, receiver_id) VALUES ("' . $lstrList . '","' . $lintID . '")';
//                $app->DB->exec($lstrQuery);
//            }
//            return "newReceiverCreated";
//        }
//    }
//}
