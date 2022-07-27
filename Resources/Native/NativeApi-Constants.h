typedef int API_TYPE;

#define API_TYPE_WIN 0
#define API_TYPE_MAC 1

typedef int SESSION_OPENRESULT;

#define SESSION_OPENRESULT_OK 0

#define SESSION_OPENRESULT_SERVERSTARTERROR 101
#define SESSION_OPENRESULT_WRONGTHREAD 102
#define SESSION_OPENRESULT_NOTPERMITTED 103
#define SESSION_OPENRESULT_UNKNOWNERROR 104

typedef int SESSION_CLOSERESULT;

#define SESSION_CLOSERESULT_OK 0

/* ================================
   High-precision tick generator
================================ */

typedef int TGSESSION_OPENRESULT;

#define TGSESSION_OPENRESULT_OK 0

#define TGSESSION_OPENRESULT_FAILEDTOGETTIMEBASEINFO 101
#define TGSESSION_OPENRESULT_FAILEDTOSETREALTIMEPRIORITY 102

typedef int TGSESSION_CLOSERESULT;

#define TGSESSION_CLOSERESULT_OK 0

typedef int TG_STARTRESULT;

#define TG_STARTRESULT_OK 0

#define TG_STARTRESULT_CANTGETDEVICECAPABILITIES 1
#define TG_STARTRESULT_CANTSETTIMERCALLBACK 2

#define TG_STARTRESULT_NORESOURCES 101
#define TG_STARTRESULT_BADTHREADATTRIBUTE 102
#define TG_STARTRESULT_UNKNOWNERROR 199

typedef int TG_STOPRESULT;

#define TG_STOPRESULT_OK 0

#define TG_STOPRESULT_CANTENDPERIOD 1
#define TG_STOPRESULT_CANTKILLEVENT 2

/* ================================
   Input device
================================ */

typedef int IN_GETINFORESULT;

#define IN_GETINFORESULT_OK 0

#define IN_GETINFORESULT_BADDEVICEID 1
#define IN_GETINFORESULT_INVALIDSTRUCTURE 2
#define IN_GETINFORESULT_NODRIVER 3
#define IN_GETINFORESULT_NOMEMORY 4

typedef int IN_OPENRESULT;

#define IN_OPENRESULT_OK 0

#define IN_OPENRESULT_ALLOCATED 1
#define IN_OPENRESULT_BADDEVICEID 2
#define IN_OPENRESULT_INVALIDFLAG 3
#define IN_OPENRESULT_INVALIDSTRUCTURE 4
#define IN_OPENRESULT_NOMEMORY 5

#define IN_OPENRESULT_PREPAREBUFFER_NOMEMORY 6
#define IN_OPENRESULT_PREPAREBUFFER_INVALIDHANDLE 7
#define IN_OPENRESULT_PREPAREBUFFER_INVALIDADDRESS 8

#define IN_OPENRESULT_ADDBUFFER_NOMEMORY 9
#define IN_OPENRESULT_ADDBUFFER_STILLPLAYING 10
#define IN_OPENRESULT_ADDBUFFER_UNPREPARED 11
#define IN_OPENRESULT_ADDBUFFER_INVALIDHANDLE 12
#define IN_OPENRESULT_ADDBUFFER_INVALIDSTRUCTURE 13

#define IN_OPENRESULT_INVALIDCLIENT 101
#define IN_OPENRESULT_INVALIDPORT 102
#define IN_OPENRESULT_WRONGTHREAD 103
#define IN_OPENRESULT_NOTPERMITTED 104

#define IN_OPENRESULT_UNKNOWNERROR 1000

typedef int IN_CLOSERESULT;

#define IN_CLOSERESULT_OK 0

#define IN_CLOSERESULT_RESET_INVALIDHANDLE 1

#define IN_CLOSERESULT_CLOSE_STILLPLAYING 2
#define IN_CLOSERESULT_CLOSE_INVALIDHANDLE 3
#define IN_CLOSERESULT_CLOSE_NOMEMORY 4

#define IN_CLOSERESULT_UNPREPAREBUFFER_STILLPLAYING 5
#define IN_CLOSERESULT_UNPREPAREBUFFER_INVALIDSTRUCTURE 6
#define IN_CLOSERESULT_UNPREPAREBUFFER_INVALIDHANDLE 7

typedef int IN_PREPARESYSEXBUFFERRESULT;

#define IN_PREPARESYSEXBUFFERRESULT_OK 0

#define IN_PREPARESYSEXBUFFERRESULT_PREPAREBUFFER_NOMEMORY 1
#define IN_PREPARESYSEXBUFFERRESULT_PREPAREBUFFER_INVALIDHANDLE 2
#define IN_PREPARESYSEXBUFFERRESULT_PREPAREBUFFER_INVALIDADDRESS 3

#define IN_PREPARESYSEXBUFFERRESULT_ADDBUFFER_NOMEMORY 4
#define IN_PREPARESYSEXBUFFERRESULT_ADDBUFFER_STILLPLAYING 5
#define IN_PREPARESYSEXBUFFERRESULT_ADDBUFFER_UNPREPARED 6
#define IN_PREPARESYSEXBUFFERRESULT_ADDBUFFER_INVALIDHANDLE 7
#define IN_PREPARESYSEXBUFFERRESULT_ADDBUFFER_INVALIDSTRUCTURE 8

typedef int IN_UNPREPARESYSEXBUFFERRESULT;

#define IN_UNPREPARESYSEXBUFFERRESULT_OK 0

#define IN_UNPREPARESYSEXBUFFERRESULT_STILLPLAYING 1
#define IN_UNPREPARESYSEXBUFFERRESULT_INVALIDSTRUCTURE 2
#define IN_UNPREPARESYSEXBUFFERRESULT_INVALIDHANDLE 3

typedef int IN_RENEWSYSEXBUFFERRESULT;

#define IN_RENEWSYSEXBUFFERRESULT_OK 0

#define IN_RENEWSYSEXBUFFERRESULT_PREPAREBUFFER_NOMEMORY 1
#define IN_RENEWSYSEXBUFFERRESULT_PREPAREBUFFER_INVALIDHANDLE 2
#define IN_RENEWSYSEXBUFFERRESULT_PREPAREBUFFER_INVALIDADDRESS 3

#define IN_RENEWSYSEXBUFFERRESULT_ADDBUFFER_NOMEMORY 4
#define IN_RENEWSYSEXBUFFERRESULT_ADDBUFFER_STILLPLAYING 5
#define IN_RENEWSYSEXBUFFERRESULT_ADDBUFFER_UNPREPARED 6
#define IN_RENEWSYSEXBUFFERRESULT_ADDBUFFER_INVALIDHANDLE 7
#define IN_RENEWSYSEXBUFFERRESULT_ADDBUFFER_INVALIDSTRUCTURE 8

#define IN_RENEWSYSEXBUFFERRESULT_UNPREPAREBUFFER_STILLPLAYING 9
#define IN_RENEWSYSEXBUFFERRESULT_UNPREPAREBUFFER_INVALIDSTRUCTURE 10
#define IN_RENEWSYSEXBUFFERRESULT_UNPREPAREBUFFER_INVALIDHANDLE 11

typedef int IN_CONNECTRESULT;

#define IN_CONNECTRESULT_OK 0

#define IN_CONNECTRESULT_INVALIDHANDLE 1

#define IN_CONNECTRESULT_UNKNOWNERROR 101
#define IN_CONNECTRESULT_INVALIDPORT 102
#define IN_CONNECTRESULT_WRONGTHREAD 103
#define IN_CONNECTRESULT_NOTPERMITTED 104
#define IN_CONNECTRESULT_UNKNOWNENDPOINT 105
#define IN_CONNECTRESULT_WRONGENDPOINT 106

typedef int IN_DISCONNECTRESULT;

#define IN_DISCONNECTRESULT_OK 0

#define IN_DISCONNECTRESULT_INVALIDHANDLE 1

#define IN_DISCONNECTRESULT_UNKNOWNERROR 101
#define IN_DISCONNECTRESULT_INVALIDPORT 102
#define IN_DISCONNECTRESULT_WRONGTHREAD 103
#define IN_DISCONNECTRESULT_NOTPERMITTED 104
#define IN_DISCONNECTRESULT_UNKNOWNENDPOINT 105
#define IN_DISCONNECTRESULT_WRONGENDPOINT 106
#define IN_DISCONNECTRESULT_NOCONNECTION 107

typedef int IN_GETEVENTDATARESULT;

#define IN_GETEVENTDATARESULT_OK 0

typedef int IN_GETSYSEXDATARESULT;

#define IN_GETSYSEXDATARESULT_OK 0

typedef int IN_PROPERTY;

#define IN_PROPERTY_PRODUCT 0
#define IN_PROPERTY_MANUFACTURER 1
#define IN_PROPERTY_DRIVERVERSION 2
#define IN_PROPERTY_UNIQUEID 3
#define IN_PROPERTY_DRIVEROWNER 4

typedef int IN_GETPROPERTYRESULT;

#define IN_GETPROPERTYRESULT_OK 0

#define IN_GETPROPERTYRESULT_UNKNOWNENDPOINT 101
#define IN_GETPROPERTYRESULT_TOOLONG 102
#define IN_GETPROPERTYRESULT_UNKNOWNPROPERTY 103
#define IN_GETPROPERTYRESULT_UNKNOWNERROR 104

/* ================================
   Output device
================================ */

typedef int OUT_GETINFORESULT;

#define OUT_GETINFORESULT_OK 0

#define OUT_GETINFORESULT_BADDEVICEID 1
#define OUT_GETINFORESULT_INVALIDSTRUCTURE 2
#define OUT_GETINFORESULT_NODRIVER 3
#define OUT_GETINFORESULT_NOMEMORY 4

typedef int OUT_OPENRESULT;

#define OUT_OPENRESULT_OK 0

#define OUT_OPENRESULT_ALLOCATED 1
#define OUT_OPENRESULT_BADDEVICEID 2
#define OUT_OPENRESULT_INVALIDFLAG 3
#define OUT_OPENRESULT_INVALIDSTRUCTURE 4
#define OUT_OPENRESULT_NOMEMORY 5

#define OUT_OPENRESULT_INVALIDCLIENT 101
#define OUT_OPENRESULT_INVALIDPORT 102
#define OUT_OPENRESULT_WRONGTHREAD 103
#define OUT_OPENRESULT_NOTPERMITTED 104
#define OUT_OPENRESULT_UNKNOWNERROR 105

typedef int OUT_CLOSERESULT;

#define OUT_CLOSERESULT_OK 0

#define OUT_CLOSERESULT_RESET_INVALIDHANDLE 1
#define OUT_CLOSERESULT_CLOSE_STILLPLAYING 2
#define OUT_CLOSERESULT_CLOSE_INVALIDHANDLE 3
#define OUT_CLOSERESULT_CLOSE_NOMEMORY 4

typedef int OUT_SENDSHORTRESULT;

#define OUT_SENDSHORTRESULT_OK 0

#define OUT_SENDSHORTRESULT_BADOPENMODE 1
#define OUT_SENDSHORTRESULT_NOTREADY 2
#define OUT_SENDSHORTRESULT_INVALIDHANDLE 3

#define OUT_SENDSHORTRESULT_INVALIDCLIENT 101
#define OUT_SENDSHORTRESULT_INVALIDPORT 102
#define OUT_SENDSHORTRESULT_WRONGENDPOINT 103
#define OUT_SENDSHORTRESULT_UNKNOWNENDPOINT 104
#define OUT_SENDSHORTRESULT_COMMUNICATIONERROR 105
#define OUT_SENDSHORTRESULT_SERVERSTARTERROR 106
#define OUT_SENDSHORTRESULT_WRONGTHREAD 107
#define OUT_SENDSHORTRESULT_NOTPERMITTED 108
#define OUT_SENDSHORTRESULT_UNKNOWNERROR 109

typedef int OUT_SENDSYSEXRESULT;

#define OUT_SENDSYSEXRESULT_OK 0

#define OUT_SENDSYSEXRESULT_PREPAREBUFFER_INVALIDHANDLE 1
#define OUT_SENDSYSEXRESULT_PREPAREBUFFER_INVALIDADDRESS 2
#define OUT_SENDSYSEXRESULT_PREPAREBUFFER_NOMEMORY 3
#define OUT_SENDSYSEXRESULT_NOTREADY 4
#define OUT_SENDSYSEXRESULT_UNPREPARED 5
#define OUT_SENDSYSEXRESULT_INVALIDHANDLE 6
#define OUT_SENDSYSEXRESULT_INVALIDSTRUCTURE 7

#define OUT_SENDSYSEXRESULT_INVALIDCLIENT 101
#define OUT_SENDSYSEXRESULT_INVALIDPORT 102
#define OUT_SENDSYSEXRESULT_WRONGENDPOINT 103
#define OUT_SENDSYSEXRESULT_UNKNOWNENDPOINT 104
#define OUT_SENDSYSEXRESULT_COMMUNICATIONERROR 105
#define OUT_SENDSYSEXRESULT_SERVERSTARTERROR 106
#define OUT_SENDSYSEXRESULT_WRONGTHREAD 107
#define OUT_SENDSYSEXRESULT_NOTPERMITTED 108
#define OUT_SENDSYSEXRESULT_UNKNOWNERROR 109

typedef int OUT_GETSYSEXDATARESULT;

#define OUT_GETSYSEXDATARESULT_OK 0

#define OUT_GETSYSEXDATARESULT_STILLPLAYING 1
#define OUT_GETSYSEXDATARESULT_INVALIDSTRUCTURE 2
#define OUT_GETSYSEXDATARESULT_INVALIDHANDLE 3

typedef int OUT_PROPERTY;

#define OUT_PROPERTY_PRODUCT 0
#define OUT_PROPERTY_MANUFACTURER 1
#define OUT_PROPERTY_DRIVERVERSION 2
#define OUT_PROPERTY_TECHNOLOGY 3
#define OUT_PROPERTY_UNIQUEID 4
#define OUT_PROPERTY_VOICESNUMBER 5
#define OUT_PROPERTY_NOTESNUMBER 6
#define OUT_PROPERTY_CHANNELS 7
#define OUT_PROPERTY_OPTIONS 8
#define OUT_PROPERTY_DRIVEROWNER 9

typedef int OUT_GETPROPERTYRESULT;

#define OUT_GETPROPERTYRESULT_OK 0

#define OUT_GETPROPERTYRESULT_UNKNOWNENDPOINT 101
#define OUT_GETPROPERTYRESULT_TOOLONG 102
#define OUT_GETPROPERTYRESULT_UNKNOWNPROPERTY 103
#define OUT_GETPROPERTYRESULT_UNKNOWNERROR 104

typedef int OUT_TECHNOLOGY;

#define OUT_TECHNOLOGY_UNKNOWN 0

#define OUT_TECHNOLOGY_MIDIPORT 1
#define OUT_TECHNOLOGY_SYNTH 2
#define OUT_TECHNOLOGY_SQSYNTH 3
#define OUT_TECHNOLOGY_FMSYNTH 4
#define OUT_TECHNOLOGY_MAPPER 5
#define OUT_TECHNOLOGY_WAVETABLE 6
#define OUT_TECHNOLOGY_SWSYNTH 7

typedef int OUT_OPTION;

#define OUT_OPTION_UNKNOWN 0

#define OUT_OPTION_CACHE 1
#define OUT_OPTION_LRVOLUME 2
#define OUT_OPTION_STREAM 4
#define OUT_OPTION_VOLUME 8

/* ================================
 Virtual device
 ================================ */
 
typedef int VIRTUAL_OPENRESULT;
 
#define VIRTUAL_OPENRESULT_OK 0

#define VIRTUAL_OPENRESULT_CREATESOURCE_NOTPERMITTED 101
#define VIRTUAL_OPENRESULT_CREATESOURCE_SERVERSTARTERROR 102
#define VIRTUAL_OPENRESULT_CREATESOURCE_WRONGTHREAD 103
#define VIRTUAL_OPENRESULT_CREATESOURCE_UNKNOWNERROR 104
#define VIRTUAL_OPENRESULT_CREATEDESTINATION_NOTPERMITTED 105
#define VIRTUAL_OPENRESULT_CREATEDESTINATION_SERVERSTARTERROR 106
#define VIRTUAL_OPENRESULT_CREATEDESTINATION_WRONGTHREAD 107
#define VIRTUAL_OPENRESULT_CREATEDESTINATION_UNKNOWNERROR 108

typedef int VIRTUAL_CLOSERESULT;
 
#define VIRTUAL_CLOSERESULT_OK 0

#define VIRTUAL_CLOSERESULT_DISPOSESOURCE_UNKNOWNENDPOINT 101
#define VIRTUAL_CLOSERESULT_DISPOSESOURCE_NOTPERMITTED 102
#define VIRTUAL_CLOSERESULT_DISPOSESOURCE_UNKNOWNERROR 103
#define VIRTUAL_CLOSERESULT_DISPOSEDESTINATION_UNKNOWNENDPOINT 104
#define VIRTUAL_CLOSERESULT_DISPOSEDESTINATION_NOTPERMITTED 105
#define VIRTUAL_CLOSERESULT_DISPOSEDESTINATION_UNKNOWNERROR 106

typedef int VIRTUAL_SENDBACKRESULT;
 
#define VIRTUAL_SENDBACKRESULT_OK 0

#define VIRTUAL_SENDBACKRESULT_UNKNOWNENDPOINT 101
#define VIRTUAL_SENDBACKRESULT_WRONGENDPOINT 102
#define VIRTUAL_SENDBACKRESULT_NOTPERMITTED 103
#define VIRTUAL_SENDBACKRESULT_SERVERSTARTERROR 104
#define VIRTUAL_SENDBACKRESULT_WRONGTHREAD 105
#define VIRTUAL_SENDBACKRESULT_UNKNOWNERROR 106
#define VIRTUAL_SENDBACKRESULT_MESSAGESENDERROR 107