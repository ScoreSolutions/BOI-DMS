--------------------------------------------------------------------------------
                           Fujitsu Scanner Control SDK

                                     V2.1L31

                                    2011年10月

                        Copyright PFU LIMITED 2002-2011

--------------------------------------------------------------------------------

  ［目次］

  １．動作環境

  ２．構成

  ３．インストール

  ４．アンインストール

  ５．注意事項

  ６．Windows Vista使用時の注意事項

  ７．おわりに


■高度な安全性が要求される用途への使用について
    本製品は、一般事務用、パーソナル用、家庭用、通常の産業等の一般的用途を想定
  して開発・設計・製造されているものであり、原子力施設における核反応制御、航空
  機自動飛行制御、航空交通管制、大量輸送システムにおける運行制御、生命維持の
  ための医療用機器、兵器システムにおけるミサイル発射制御など、極めて高度な安全
  性が要求され、仮に当該安全性が確保されない場合、直接生命・身体に対する重大な
  危険性を伴う用途（以下「ハイセイフティ用途」という）に使用されるよう開発・
  設計・製造されたものではありません。
    お客さまは本製品を必要な安全性を確保する措置を施すことなくハイセイフティ
  用途に使用しないでください。また、お客さまがハイセイフティ用途に本製品を使用
  したことにより発生する、お客様または第三者からのいかなる請求または損害賠償に
  対しても株式会社ＰＦＵおよびその関連会社は一切責任を負いかねます。


--------------------------------------------------------------------------------

１．動作環境

  (1)本体システム
     本体   ：  本体：PC/AT互換機
     ＯＳ   ：  Windows(R) 2000 Professional
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


  (2)イメージスキャナ装置
    以下の富士通製fiシリーズスキャナがご使用いただけます。
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
    イメージスキャナ装置のデバイスドライバは、本製品に添付のFUJITSU TWAIN32
    Version 9.18 (fi-4340C、fi-4860C2) / 9.19 (fi-5015C) / 9.21 (fi-4340C、
    fi-4860C2、fi-5015C、fi-5950、fi-6800、fi-6110、fi-6130Z、fi-6230Z、
    fi-6140Z、fi-6240Z以外) / 10.10 (fi-5950、fi-6800) / 10.20 (fi-6110) /
    10.21 (fi-6130Z、fi-6230Z、fi-6140Z、fi-6240Z) 以降の版数をお使いください。

  (3)開発環境
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
    本製品には、これらの開発環境でご覧いただけるサンプルソースコードと、実行
    形式が添付されております。


--------------------------------------------------------------------------------

２．構成

  Fujitsu Scanner Control SDK V2.1L31 の構成を説明します｡
  インストールされたファイルをお確かめください｡

  <Program Files>はインストール時に指定したディレクトリを示します。

  <Program Files Common>はシステムがインストールされたドライブが C ドライブの
  場合、以下を示します。
     Windows 2000の場合                   "C:\Program Files\Common Files"
     Windows XP(32bit)の場合              "C:\Program Files\Common Files"
     Windows XP(64bit)の場合              "C:\Program Files (x86)\Common Files"
     Windows Server 2003(32bit)の場合     "C:\Program Files\Common Files"
     Windows Server 2003(64bit)の場合     "C:\Program Files (x86)\Common Files"
     Windows Vista(32bit)の場合           "C:\Program Files\Common Files"
     Windows Vista(64bit)の場合           "C:\Program Files (x86)\Common Files"
     Windows Server 2008(32bit)の場合     "C:\Program Files\Common Files"
     Windows Server 2008(64bit)の場合     "C:\Program Files (x86)\Common Files"
     Windows 7(32bit)の場合               "C:\Program Files\Common Files"
     Windows 7(64bit)の場合               "C:\Program Files (x86)\Common Files"

  <Windows System Folder>はシステムがインストールされたドライブが C ドライブの
  場合、以下を示します。
     Windows 2000の場合                   "C:\WINNT\System32"
     Windows XP(32bit)の場合              "C:\Windows\System32"
     Windows XP(64bit)の場合              "C:\Windows\SysWOW64"
     Windows Server 2003(32bit)の場合     "C:\Windows\System32"
     Windows Server 2003(64bit)の場合     "C:\Windows\SysWOW64"
     Windows Vista(32bit)の場合           "C:\Windows\System32"
     Windows Vista(64bit)の場合           "C:\Windows\SysWOW64"
     Windows Server 2008(32bit)の場合     "C:\Windows\System32"
     Windows Server 2008(64bit)の場合     "C:\Windows\SysWOW64"
     Windows 7(32bit)の場合               "C:\Windows\System32"
     Windows 7(64bit)の場合               "C:\Windows\SysWOW64"

  インストールおよび、動作に必要なファイルは、以下の通りです。
     <Program Files>\FiScn.ocx                   （本体）
     <Program Files>\FiScn11.dll                 （日本語モジュール）
     <Program Files>\FiScn.dll                   （Java用モジュール）
     <Program Files>\FiScn.lic                   （ライセンスファイル）
     <Program Files>\Fiscn.jar                   （Javaアーカイブ）
     <Program Files>\LICENSE.TXT                 （ライセンスファイル）
     <Program Files>\Readme.txt                  （Readmeファイル）
     <Program Files>\manual\Manual.pdf           （リファレンスマニュアル)
     <Program Files>\manual\Javadoc\index.html    (Javadoc)
     <Program Files>\Sample                      （サンプル格納先フォルダ）

     <Program Files Common>\Fujitsu\Scanner Control SDK\P2IBSKEW.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\P2IERSDW.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\P2Igr2mo.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\P2IJDGWP.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\p2iunite.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\ssIpl.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplA6.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplM5.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplM6.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplP6.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplPX.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\ssIplW7.dll
                                                 （キャリアシートライブラリ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\Fiscn.jar
                                                 （Javaアーカイブ）
     <Program Files Common>\Fujitsu\Scanner Control SDK\FiScn.dll
                                                 （Java用モジュール）

     <Windows System Folder>\FiScn.ocx   （本体）
     <Windows System Folder>\FiScn11.dll （日本語モジュール）
     <Windows System Folder>\FiScn.lic   （ライセンスファイル）
     <Windows System Folder>\RegSrv32.exe（OCX登録／解除モジュール）
     <Windows System Folder>\MFC42.dll   （MFC6.2ランタイムライブラリ）
     <Windows System Folder>\MSVCRT.dll  （Visual C++ランタイムライブラリ）
     <Windows System Folder>\OLEPRO32.dll（OLEオートメーションファイル群の1つ）
     <Windows System Folder>\OLEAUT32.dll（OLEオートメーションファイル群の1つ）

     <Windows System Folder>\Mfc42u.dll  （MFC6.2ランタイムライブラリ）
     <Windows System Folder>\Msvcp60.dll （MFC6.2ランタイムライブラリ）
     <Windows System Folder>\Mfc42Loc.dll（MFC6.2ランタイムライブラリ）

     <Windows System Folder>\Msvbvm60.dll（Visual Basic6ランタイムライブラリ）
     <Windows System Folder>\Stdole2.tlb （Visual Basic6ランタイムライブラリ）
     <Windows System Folder>\Asycfilt.dll（Visual Basic6ランタイムライブラリ）
     <Windows System Folder>\Comcat.dll  （Visual Basic6ランタイムライブラリ）
     <Windows System Folder>\Vb5db.dll   （Visual Basic6ランタイムライブラリ）
     <Windows System Folder>\Vb6de.dll   （Visual Basic6ランタイムライブラリ）
     <Windows System Folder>\Vb6jp.dll   （Visual Basic6ランタイムライブラリ）
     <Windows System Folder>\MSCOMJP.DLL （Visual Basic6ランタイムライブラリ）

     <Windows System Folder>\mfc71.dll   （MFC7.1ランタイムライブラリ）
     <Windows System Folder>\mfc71u.dll  （MFC7.1ランタイムライブラリ）
     <Windows System Folder>\msvcr71.dll （MFC7.1ランタイムライブラリ）

     <Windows System Folder>\mfc100.dll  （MFC100ランタイムライブラリ）
     <Windows System Folder>\mfc100u.dll （MFC100ランタイムライブラリ）
     <Windows System Folder>\mfcm100.dll （MFC100ランタイムライブラリ）
     <Windows System Folder>\mfcm100u.dll（MFC100ランタイムライブラリ）
     <Windows System Folder>\msvcr100.dll（MFC100ランタイムライブラリ）
     <Windows System Folder>\msvcp100.dll（MFC100ランタイムライブラリ）


--------------------------------------------------------------------------------

３．インストール

  ・本製品のインストールについては、本製品のリファレンスマニュアルを参照して
    ください。

  ・ルートディレクトリに直接インストールはしないでください。正常に動作しない
    場合があります。適当なディレクトリにインストールしてください。

  ・インストール先のパス名長が184文字以上の場合、インストールは失敗します。
    インストール先のパス名長は、183文字以内でインストールして下さい。

  ・インストールする場合は、Administrator権限 (Windows XP Home Edition では
    コンピュータの管理者権限) のあるユーザ名でログインしてからインストール
    してください。

  ・インストール先のディレクトリ名に下記に示す文字を使用しないでください。
    使用するとプログラムが正常に動作しない場合があります。
    \ / ; : , . * ? " < > |

  ・既に本製品がインストールされている場合の上書きインストールはできません。
    再インストールを行なう場合は、先にアンインストールしてください。


--------------------------------------------------------------------------------

４．アンインストール

  ・本製品のアンインストールについては、本製品のリファレンスマニュアルをご参照
    してください。

  ・アンインストール時に「共有ファイルを削除しますか？」のメッセージで共有
    ファイルを削除すると、他のプログラムがまだこのファイルを使用している場合、
    プログラムが動かなくなる恐れがあります。

  ・アンインストールする場合は、Administrator権限 (Windows XP Home Edition では
    コンピュータの管理者権限) のあるユーザ名でログインしてからアンインストール
    してください。


--------------------------------------------------------------------------------

５．注意事項

  ・本製品のリファレンスマニュアルを表示する場合、
    Adobe(R) Reader(TM) 7.0.8 以降をお使いください。

  ・本製品をお使いになる前に、FUJITSU TWAIN32デバイスドライバのREADMEファイルも
    必ずご覧ください。
    READMEファイルは、この製品をお使いになる前にお読みいただきたい注意事項や、
    オンラインヘルプなどに含まれていない最新の追加情報が含まれています。

  ・イメージスキャナ装置の読み取りにおいて、スキャナ選択（ソースの選択）で選択
    中のデバイスドライバで動作しないことがあります。デバイスドライバのインスト
    ール直後のイメージスキャナ装置の読み取り前に、１度スキャナ選択を行ってから
    お使いください。

  ・fi-5015Cイメージスキャナ装置で、画像タイプにハーフトーンを選択した場合、
    ブランクページスキップ機能は使用できません。
    ブランクページスキップ機能を使用する場合は、画像タイプにハーフトーン以外を
    指定してご利用ください。

  ・本製品は32bitアプリケーション用ライブラリです。64bitオペレーティング
    システム上でもご利用になれますが、64bitアプリケーションは開発できません。
    64bitオペレーティングシステム上でVisual Basic 2005、Visual Basic 2008、
    Visual Basic 2010をご利用になられる場合は、コンパイルオプションのターゲット
    CPUをx86に変更してください。
    64bitオペレーティングシステム上でVisual C# 2005、Visual C# 2008、
    Visual C# 2010をご利用になられる場合は、ビルドのプラットフォーム ターゲット
    をx86に変更してください。
    Javaをご使用になられる場合は、64bitオペレーティングシステム上でも、32bit版
    をご使用ください。

  ・TWAINドライバの[オプション]->[動作]タブのキャッシュモードが「両メモリ使用」
    に設定されている場合、用紙詰まりエラーが通知されない場合があります。その
    ような場合には、TWAINドライバのキャッシュモードを「両メモリ使用」以外に
    設定してください。

  ・64bit OS環境にScandAll PRO V1.5以前と本製品の両方をインストールし、
    ScandAll PROをアンインストール、または、ScandAll PRO V1.5.1以降を上書き
    インストールした場合、本製品で開発したアプリケーションの使用や開発環境での
    ビルドができなくなります。その場合は、再度本製品をインストールして
    ください。

  ・本製品でA3キャリアシートを使用する場合は、ScanSnap A3キャリアシートをご購入
    下さい。

  ・SDKをご使用になられているアプリケーション側のメモリ使用量にもよりますが、
    高解像度でのキャリアシート読み取りにおいてメモリ不足のエラーが発生すること
    があります。
    メモリ不足のエラーが発生した場合は、解像度を下げて読み取りを行って
    ください。

  ・本製品のJavadocを表示する場合、Microsoft(R) Internet Explorer(R) 6.0 以降を
    お使いください。

--------------------------------------------------------------------------------

６．Windows Vista使用時の注意事項

  ・Fujitsu Scanner Control SDK は環境依存文字（unicode）には対応していません。
    Fujitsu Scanner Control SDK のインストール先、Fujitsu Scanner Control SDK 
    を使用するときのユーザー名、Fujitsu Scanner Control SDK で扱うフォルダ名、
    ファイル名、その他の文字列に、環境依存文字（unicode）を使用しないで
    ください。


--------------------------------------------------------------------------------

７．おわりに

  この製品は、以下のコンポーネントを使用しています。

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


  富士通、FUJITSU は、富士通株式会社の登録商標です。
  Microsoft､Windows､Windows Vista、Windows Server、Visual Basic、Visual C++
  および Visual C# は米国 Microsoft Corporation の米国およびその他の国における
  登録商標または商標です。
  JavaおよびすべてのJava関連の商標およびロゴは、米国およびその他の国における
  米国Sun Microsystems,Inc.の商標または登録商標です。
  Sun、Sun Microsystems、Sunロゴ、SolarisおよびすべてのSolarisに関連する商標
  及びロゴは、米国およびその他の国における米国Sun Microsystems, Inc.の商標また
  は登録商標です。
  Adobe Reader はAdobe Systems Incorporated (アドビシステムズ社)の登録商標
  です。
  その他の一般製品名、社名は各社の商標または登録商標です。

                                                                            以上
