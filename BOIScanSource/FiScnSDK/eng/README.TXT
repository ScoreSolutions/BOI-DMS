--------------------------------------------------------------------------------
                          Fujitsu Scanner Control SDK

                                     V2.1L31

                                   October , 2011

                        Copyright PFU LIMITED 2002-2011

--------------------------------------------------------------------------------
[Contents]

1.  Operation Environment
2.  Program Contents
3.  Installation
4.  Uninstallation
5.  Cautions
6.  Cautions for Windows Vista Users
7.  Closing Note

[High Safety Required Use]
   This Product is designed, developed and manufactured as contemplated for
   general use, including without limitation, general office use, personal use,
   household use, and ordinary industrial use, but is not designed, developed
   and manufactured as contemplated for use accompanying fatal risks or
   dangers that, unless extremely high safety is secured, could lead directly
   to death, personal injury, severe physical damage or other loss
   (hereinafter "High Safety Required Use"), including without limitation,
   nuclear power reactioncore control in nuclearatomic facility, airplane
   automaticaircraft flight control, air traffic control, operation control in
   mass transport controlsystem, medical instrument for life support system,
   missile launching control in weapon system.
   You shall not use this Product without securing the sufficient safety
   required for the High Safety Required Use.
   In addition, PFU (or other affiliated company) shall not be liable against
   the Customer and/or any third party for any claims or damages arising in
   connection with the High Safety Required Use of the Product.

--------------------------------------------------------------------------------

1. Operation Environment

(1)  Main system
     Main unit: PC/AT compatible
     Platform   Windows(R) 2000 Professional
                Windows(R) XP Home Edition
                Windows(R) XP Professional
                Windows(R) XP Professional x64 Edition
                Windows Server(R) 2003, Standard Edition
                Windows Server(R) 2003 R2, Standard Edition
                Windows Server(R) 2003 R2, Standard x64 Edition
                Windows Vista(R) Home Basic (32/64bit)
                Windows Vista(R) Home Premium (32/64bit)
                Windows Vista(R) Business (32/64bit)
                Windows Vista(R) Enterprise (32/64bit)
                Windows Vista(R) Ultimate (32/64bit)
                Windows Server(R) 2008 Standard (32/64bit)
                Windows Server(R) 2008 R2 Standard (64bit)
                Windows(R) 7 Home Premium (32/64bit)
                Windows(R) 7 Professional (32/64bit)
                Windows(R) 7 Enterprise (32/64bit)
                Windows(R) 7 Ultimate (32/64bit)

(2) Image scanner
    The Fujitsu fi-series scanners below can be used:
        - fi-6800
        - fi-6770
        - fi-6770A
        - fi-6750S
        - fi-6670
        - fi-6670A
        - fi-6240Z
        - fi-6240
        - fi-6140Z
        - fi-6140
        - fi-6230Z
        - fi-6230
        - fi-6130Z
        - fi-6130
        - fi-6110
        - fi-5950
        - fi-5900C
        - fi-5750C
        - fi-5650C
        - fi-5530C
        - fi-5530C2
        - fi-5220C
        - fi-5120C
        - fi-5110C
        - fi-5015C
        - fi-4860C2
        - fi-4340C
        - fi-60F
    Use FUJITSU TWAIN32 Version 9.18(fi-4340C and fi-4860C2) /
    9.19 (fi-5015C) / 9.21(any model other than the fi-4340C, fi-4860C2,
    fi-5015C, fi-5950, fi-6800, fi-6110, fi-6130Z, fi-6230Z,fi-6140Z and
    fi-6240Z) / 10.10 (fi-5950 and fi-6800) / 10.20 (fi-6110) /
    10.21 (fi-6130Z, fi-6230Z,fi-6140Z and fi-6240Z) or later for the device
    driver of image scanners.

(3) Development environment
    - Microsoft(R) Visual Basic(R).NET 2003
    - Microsoft(R) Visual Basic(R) 2005
    - Microsoft(R) Visual Basic(R) 2008
    - Microsoft(R) Visual Basic(R) 2010
    - Microsoft(R) Visual C++(R).NET 2003
    - Microsoft(R) Visual C++(R) 2005
    - Microsoft(R) Visual C++(R) 2008
    - Microsoft(R) Visual C++(R) 2010
    - Microsoft(R) Visual C#(R).NET 2003
    - Microsoft(R) Visual C#(R) 2005
    - Microsoft(R) Visual C#(R) 2008
    - Microsoft(R) Visual C#(R) 2010
    - Java(TM) SE Development Kit (JDK(TM)) 6
    Sample source codes and executable files that can be viewed in the above
    environments are attached to this Product.


--------------------------------------------------------------------------------

2. Program Contents

  The following explains the contents of Fujitsu Scanner Control SDK V2.1L31.
  Check the file installed.

  < Program Files> displays the folder specified when installed.

  < Program Files Common> displays the following if the system is installed to
  your C drive.
   On Windows 2000                      "C:\Program Files\Common Files"
   On Windows XP(32bit)                 "C:\Program Files\Common Files"
   On Windows XP(64bit)                 "C:\Program Files (x86)\Common Files"
   On Windows Server 2003(32bit)        "C:\Program Files\Common Files"
   On Windows Server 2003(64bit)        "C:\Program Files (x86)\Common Files"
   On Windows Vista(32bit)              "C:\Program Files\Common Files"
   On Windows Vista(64bit)              "C:\Program Files (x86)\Common Files"
   On Windows Server 2008(32bit)        "C:\Program Files\Common Files"
   On Windows Server 2008(64bit)        "C:\Program Files (x86)\Common Files"
   On Windows 7(32bit)                  "C:\Program Files\Common Files"
   On Windows 7(64bit)                  "C:\Program Files (x86)\Common Files"

  < Windows System Folder> displays the following if the system is installed to
  your C drive.
   On Windows 2000                      "C:\WINNT\System32"
   On Windows XP(32bit)                 "C:\Windows\System32"
   On Windows XP(64bit)                 "C:\Windows\SysWOW64"
   On Windows Server 2003(32bit)        "C:\Windows\System32"
   On Windows Server 2003(64bit)        "C:\Windows\SysWOW64"
   On Windows Vista(32bit)              "C:\Windows\System32"
   On Windows Vista(64bit)              "C:\Windows\SysWOW64"
   On Windows Server 2008(32bit)        "C:\Windows\System32"
   On Windows Server 2008(64bit)        "C:\Windows\SysWOW64"
   On Windows 7(32bit)                  "C:\Windows\System32"
   On Windows 7(64bit)                  "C:\Windows\SysWOW64"

  The files required for installation and operation are as follows:
   <Program Files>\FiScn.ocx                 (Main program)
   <Program Files>\FiScn11.dll               (Japanese module)
   <Program Files>\FiScn.dll                 (Java module)
   <Program Files>\FiScn.lic                 (License file)
   <Program Files>\Fiscn.jar                 (Java Archive)
   <Program Files>\LICENSE.TXT               (License file)
   <Program Files>\Readme.txt                (Readme file)
   <Program Files>\manual\Manual.pdf         (Reference file)
   <Program Files>\manual\Javadoc\index.html (Javadoc)
   <Program Files>\Sample                    (Folder containing program samples)

   <Program Files Common>\Fujitsu\Scanner Control SDK\P2IBSKEW.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\P2IERSDW.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\P2Igr2mo.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\P2IJDGWP.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\p2iunite.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\ssIpl.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplA6.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplM5.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplM6.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplP6.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplPX.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplW7.dll
                                                 (CarrierSheet library)
   <Program Files Common>\Fujitsu\Scanner Control SDK\Fiscn.jar
                                                 (Java Archive)
   <Program Files Common>\Fujitsu\Scanner Control SDK\FiScn.dll
                                                 (Java module)

   <Windows System Folder>\FiScn.ocx    (Main program)
   <Windows System Folder>\FiScn11.dll  (Japanese module)
   <Windows System Folder>\FiScn.lic    (License file)
   <Windows System Folder>\RegSrv32.exe (Module for OCX registration/removal)
   <Windows System Folder>\MFC42.dll    (MFC6.2 runtime library)
   <Windows System Folder>\MSVCRT.dll   (Visual C++ runtime library)
   <Windows System Folder>\OLEPRO32.dll (One of the OLE automation file groups)
   <Windows System Folder>\OLEAUT32.dll (One of the OLE automation file groups)

   <Windows System Folder>\Mfc42u.dll   (MFC6.2 runtime library)
   <Windows System Folder>\Msvcp60.dll  (MFC6.2 runtime library)
   <Windows System Folder>\Mfc42Loc.dll (MFC6.2 runtime library)

   <Windows System Folder>\Msvbvm60.dll (Visual Basic6 runtime library)
   <Windows System Folder>\Stdole2.tlb  (Visual Basic6 runtime library)
   <Windows System Folder>\Asycfilt.dll (Visual Basic6 runtime library)
   <Windows System Folder>\Comcat.dll   (Visual Basic6 runtime library)
   <Windows System Folder>\Vb5db.dll    (Visual Basic6 runtime library)
   <Windows System Folder>\Vb6de.dll    (Visual Basic6 runtime library)
   <Windows System Folder>\Vb6jp.dll    (Visual Basic6 runtime library)
   <Windows System Folder>\MSCOMJP.DLL  (Visual Basic6 runtime library)

   <Windows System Folder>\mfc71.dll    (MFC7.1 runtime library)
   <Windows System Folder>\mfc71u.dll   (MFC7.1 runtime library)
   <Windows System Folder>\msvcr71.dll  (MFC7.1 runtime library)

   <Windows System Folder>\mfc100.dll   (MFC100 runtime library)
   <Windows System Folder>\mfc100u.dll  (MFC100 runtime library)
   <Windows System Folder>\mfcm100.dll  (MFC100 runtime library)
   <Windows System Folder>\mfcm100u.dll (MFC100 runtime library)
   <Windows System Folder>\msvcr100.dll (MFC100 runtime library)
   <Windows System Folder>\msvcp100.dll (MFC100 runtime library)

--------------------------------------------------------------------------------

3. Installation

  - See the Reference Manual to install this Product.

  - Avoid installing directly into the root folder. If this is done, the
    program may not operate correctly. Install the program in an appropriate
    folder.

  - If the pathname for the destination location contains more than 184
    characters, the installation will fail.
    Accordingly, ensure the installation pathname does not exceed 184
    characters.

  - Login to your platform as Administrator to install the program (login as
    built-in Administrator to install the program on Windows XP Home Edition).

  - Do not use the characters shown below for the folder name of the
    destination location. If this is done, the program may not operate
    correctly.
    \ / ; : , . * ? " < > |

  - If this program already exists on your computer, overwrite installation is
    not possible. Remove the existing program prior to installation.


--------------------------------------------------------------------------------

4. Uninstallation

  - See the Reference Manual to uninstall this Product.

  - Note that if shared files are deleted when the message dialog "Do you want
    to delete the shared files?" appears, any other programs using such shared
    files may not operate correctly .

  - Login to your platform as Administrator to uninstall the program (login as
    built-in Administrator to uninstall the program on Windows XP Home
    Edition).


--------------------------------------------------------------------------------

5. Cautions

  - Use Adobe(R) Reader(TM) 7.0.8 or higher to display the Reference Manual.

  - Be sure to read the README file of the FUJITSU TWAIN32 device driver before
    using this Product.
    The README file contains notes you should read before using this productas
    well as the latest additional information not included in the online help,
    etc.

  - The image scanner device may not scan properly with the device driver
    selected using the scanner selection (source selection). If this occurs,
    after installing the device driver, carry out scanner selection again
    before attempting to use your image scanner device.

  - When you use fi-5015C image scanner device and select "Halftone" in "Image
    Mode", blank pages may not be skipped depending on the type of documents
    scanned.
    Select other than "Halftone" in "Image Mode" when you use "Blank Page
    Skip."

  - This product is a library for 32-bit applications. It can be used on the
    64-bit operaing system but cannot be used for developing 64-bit
    applications.
    If you use Visual Basic 2005, Visual Basic 2008, Visual Basic 2010 on the
    64-bit Operating System, change the target CPU of the compile option
    to x86.
    If you use Visual C# 2005, Visual C# 2008, Visual C# 2010 on the 64-bit
    Operating System, change the Platform target of the Build to x86.
    When using Java, use the 32-bit version even if your operating system is
    64-bit. 

  - Paper jams may not be reported when [Use Both Memory] is selected at
    [Cache Mode] on the [Job/Cache] tab in the [Option] dialog box of the TWAIN
    scanner driver.
    In such case, select an item other than [Use Both Memory].

  - If you install ScandAll PRO V1.5 or earlier together with this product on a
    64-bit OS, and then uninstall that ScandAll PRO or overwrite the existing
    ScandAll PRO with its later version (V1.5.1 or later), you cannot use your
    application developed by this product nor build it in any environment that
    is under development. 
    In such case, reinstall this product.

  - If you want to use the Carrier Sheet on this product, you need to purchase
    the ScanSnap's Carrier Sheet.

  - Although it depends on the actual memory size needed for the application
    for which SDK is used, a memory shortage may occur if documents are scanned
    using the Carrier Sheet at a high scanning resolution.
    If this happens, specify a lower resolution and retry the scan.

  - Use A Microsoft(R) Internet Explorer(R) 6.0 or later to display the Javadoc.

--------------------------------------------------------------------------------

6. Cautions for Windows Vista Users

  - Fujitsu Scanner Control SDK does not support environment-dependent
    characters (unicode).
    Do not use environment-dependent characters (unicode) for the following:
    - the name of a folder to install Fujitsu Scanner Control SDK
    - the name of a Fujitsu Scanner Control SDK user
    - characters including the name of folders and files handled in
      Fujitsu Scanner Control SDK

--------------------------------------------------------------------------------

7. Closing Note

  The following component is used in this product.

  libtiff

  Copyright (c) 1988-1997 Sam Leffler

  Copyright (c) 1991-1997 Silicon Graphics, Inc.

  Permission to use, copy, modify, distribute, and sell this software and its 
  documentation for any purpose is hereby granted without fee, provided that
  (i) the above copyright notices and this permission notice appear in all
  copies of the software and related documentation, and (ii) the names of Sam
  Leffler and Silicon Graphics may not be used in any advertising or publicity
  relating to the software without the specific, prior written permission of
  Sam Leffler and Silicon Graphics.

  THE SOFTWARE IS PROVIDED "AS-IS" AND WITHOUT WARRANTY OF ANY KIND, EXPRESS,
  IMPLIED OR OTHERWISE, INCLUDING WITHOUT LIMITATION, ANY WARRANTY OF
  MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE.

  IN NO EVENT SHALL SAM LEFFLER OR SILICON GRAPHICS BE LIABLE FOR ANY SPECIAL,
  INCIDENTAL, INDIRECT OR CONSEQUENTIAL DAMAGES OF ANY KIND, OR ANY DAMAGES
  WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER OR NOT
  ADVISED OF THE POSSIBILITY OF DAMAGE, AND ON ANY THEORY OF LIABILITY, ARISING
  OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.


  FUJITSU is a registered trademark of Fujitsu Limited.
  Microsoft, Windows, Windows Vista, Windows Server, Visual Basic, Visual C++
  and Visual C# are registered trademarks of Microsoft Corporation in the
  United States and/or other countries.
  Java and all Java-based trademarks and logos are trademarks or registered
  trademarks of Sun Microsystems,Inc.in the United States and other countries.
  Sun, Sun Microsystems, the Sun logo, Solaris, and all trademarks and logos
  that contain Solaris, are trademarks or registered trademarks of Sun
  Microsystems, Inc. or its subsidiaries in the United States and other
  countries.
  Adobe Reader are registered trademarks of Adobe Systems Incorporated.
  Any other products or company names appearing in this document are the
  trademarks or registered trademarks of the respective companies.

