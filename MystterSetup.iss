#define MyAppName "Mystter"
#define MyAppVersion "1.4.2"
#define MyAppPublisher "Maisu"
#define MyAppExeName MyAppName + ".exe"
#define MyAppReleaseDir ".\Releases"
#define MyAppId "20B10983-E290-46CD-A001-FADDE32D57E2"

[Setup]
AppCopyright=Copyright (C) 2016-2020 {#MyAppPublisher}
AppId={#MyAppId}
AppMutex={#MyAppId}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL=https://github.com/mystasly48/Mystter_SendTweet
AppSupportURL=https://github.com/mystasly48/Mystter_SendTweet/issues
AppUpdatesURL=https://github.com/mystasly48/Mystter_SendTweet/releases
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
OutputDir={#MyAppReleaseDir}
OutputBaseFilename=MystterSetup{#MyAppVersion}
Compression=lzma
SolidCompression=yes                 
WizardStyle=modern
UninstallDisplayIcon={app}\{#MyAppExeName}
UninstallDisplayName={#MyAppName}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "{#MyAppReleaseDir}\{#MyAppVersion}\*"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyAppReleaseDir}\{#MyAppVersion}\Languages\ja\*"; DestDir: "{app}\Languages\ja"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
