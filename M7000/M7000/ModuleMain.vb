Imports System.Math
Imports System.IO

Module ModuleMain

    Public RunM6100 As Boolean = False
    Public bSave As Boolean = False
    Public dAppendTime As Double = 0
    Public bMeas As Boolean = False

    Public Function LoadPhotopicResponseData() As Double()
        Dim PhotopicCurve(400) As Double
        PhotopicCurve(0) = 0.000039
        PhotopicCurve(1) = 0.0000428
        PhotopicCurve(2) = 0.0000469
        PhotopicCurve(3) = 0.0000516
        PhotopicCurve(4) = 0.0000572
        PhotopicCurve(5) = 0.000064
        PhotopicCurve(6) = 0.0000723
        PhotopicCurve(7) = 0.0000822
        PhotopicCurve(8) = 0.0000935
        PhotopicCurve(9) = 0.000106
        PhotopicCurve(10) = 0.00012
        PhotopicCurve(11) = 0.000135
        PhotopicCurve(12) = 0.000151
        PhotopicCurve(13) = 0.00017
        PhotopicCurve(14) = 0.000192
        PhotopicCurve(15) = 0.000217
        PhotopicCurve(16) = 0.000247
        PhotopicCurve(17) = 0.000281
        PhotopicCurve(18) = 0.000319
        PhotopicCurve(19) = 0.000357
        PhotopicCurve(20) = 0.000396
        PhotopicCurve(21) = 0.000434
        PhotopicCurve(22) = 0.000473
        PhotopicCurve(23) = 0.000518
        PhotopicCurve(24) = 0.000572
        PhotopicCurve(25) = 0.00064
        PhotopicCurve(26) = 0.000725
        PhotopicCurve(27) = 0.000826
        PhotopicCurve(28) = 0.000941
        PhotopicCurve(29) = 0.00107
        PhotopicCurve(30) = 0.00121
        PhotopicCurve(31) = 0.00136
        PhotopicCurve(32) = 0.00153
        PhotopicCurve(33) = 0.00172
        PhotopicCurve(34) = 0.00194
        PhotopicCurve(35) = 0.00218
        PhotopicCurve(36) = 0.00245
        PhotopicCurve(37) = 0.00276
        PhotopicCurve(38) = 0.00312
        PhotopicCurve(39) = 0.00353
        PhotopicCurve(40) = 0.004
        PhotopicCurve(41) = 0.00455
        PhotopicCurve(42) = 0.00516
        PhotopicCurve(43) = 0.00583
        PhotopicCurve(44) = 0.00655
        PhotopicCurve(45) = 0.0073
        PhotopicCurve(46) = 0.00809
        PhotopicCurve(47) = 0.00891
        PhotopicCurve(48) = 0.00977
        PhotopicCurve(49) = 0.01066
        PhotopicCurve(50) = 0.0116
        PhotopicCurve(51) = 0.01257
        PhotopicCurve(52) = 0.01358
        PhotopicCurve(53) = 0.01463
        PhotopicCurve(54) = 0.01572
        PhotopicCurve(55) = 0.01684
        PhotopicCurve(56) = 0.01801
        PhotopicCurve(57) = 0.01921
        PhotopicCurve(58) = 0.02045
        PhotopicCurve(59) = 0.02172
        PhotopicCurve(60) = 0.023
        PhotopicCurve(61) = 0.02429
        PhotopicCurve(62) = 0.02561
        PhotopicCurve(63) = 0.02696
        PhotopicCurve(64) = 0.02835
        PhotopicCurve(65) = 0.0298
        PhotopicCurve(66) = 0.03131
        PhotopicCurve(67) = 0.03288
        PhotopicCurve(68) = 0.03452
        PhotopicCurve(69) = 0.03623
        PhotopicCurve(70) = 0.038
        PhotopicCurve(71) = 0.03985
        PhotopicCurve(72) = 0.04177
        PhotopicCurve(73) = 0.04377
        PhotopicCurve(74) = 0.04584
        PhotopicCurve(75) = 0.048
        PhotopicCurve(76) = 0.05024
        PhotopicCurve(77) = 0.05257
        PhotopicCurve(78) = 0.05498
        PhotopicCurve(79) = 0.05746
        PhotopicCurve(80) = 0.06
        PhotopicCurve(81) = 0.0626
        PhotopicCurve(82) = 0.06528
        PhotopicCurve(83) = 0.06804
        PhotopicCurve(84) = 0.07091
        PhotopicCurve(85) = 0.0739
        PhotopicCurve(86) = 0.07702
        PhotopicCurve(87) = 0.08027
        PhotopicCurve(88) = 0.08367
        PhotopicCurve(89) = 0.08723
        PhotopicCurve(90) = 0.09098
        PhotopicCurve(91) = 0.09492
        PhotopicCurve(92) = 0.09905
        PhotopicCurve(93) = 0.10337
        PhotopicCurve(94) = 0.10788
        PhotopicCurve(95) = 0.1126
        PhotopicCurve(96) = 0.11753
        PhotopicCurve(97) = 0.12267
        PhotopicCurve(98) = 0.12799
        PhotopicCurve(99) = 0.13345
        PhotopicCurve(100) = 0.13902
        PhotopicCurve(101) = 0.14468
        PhotopicCurve(102) = 0.15047
        PhotopicCurve(103) = 0.15646
        PhotopicCurve(104) = 0.16272
        PhotopicCurve(105) = 0.1693
        PhotopicCurve(106) = 0.17624
        PhotopicCurve(107) = 0.18356
        PhotopicCurve(108) = 0.19127
        PhotopicCurve(109) = 0.19942
        PhotopicCurve(110) = 0.20802
        PhotopicCurve(111) = 0.21712
        PhotopicCurve(112) = 0.22673
        PhotopicCurve(113) = 0.23686
        PhotopicCurve(114) = 0.24748
        PhotopicCurve(115) = 0.2586
        PhotopicCurve(116) = 0.27018
        PhotopicCurve(117) = 0.28229
        PhotopicCurve(118) = 0.29505
        PhotopicCurve(119) = 0.30858
        PhotopicCurve(120) = 0.323
        PhotopicCurve(121) = 0.3384
        PhotopicCurve(122) = 0.35469
        PhotopicCurve(123) = 0.3717
        PhotopicCurve(124) = 0.38929
        PhotopicCurve(125) = 0.4073
        PhotopicCurve(126) = 0.42563
        PhotopicCurve(127) = 0.44431
        PhotopicCurve(128) = 0.46339
        PhotopicCurve(129) = 0.48294
        PhotopicCurve(130) = 0.503
        PhotopicCurve(131) = 0.52357
        PhotopicCurve(132) = 0.54451
        PhotopicCurve(133) = 0.56569
        PhotopicCurve(134) = 0.58697
        PhotopicCurve(135) = 0.6082
        PhotopicCurve(136) = 0.62935
        PhotopicCurve(137) = 0.65031
        PhotopicCurve(138) = 0.67088
        PhotopicCurve(139) = 0.69084
        PhotopicCurve(140) = 0.71
        PhotopicCurve(141) = 0.72819
        PhotopicCurve(142) = 0.74546
        PhotopicCurve(143) = 0.76197
        PhotopicCurve(144) = 0.77784
        PhotopicCurve(145) = 0.7932
        PhotopicCurve(146) = 0.80811
        PhotopicCurve(147) = 0.8225
        PhotopicCurve(148) = 0.83631
        PhotopicCurve(149) = 0.84949
        PhotopicCurve(150) = 0.862
        PhotopicCurve(151) = 0.87381
        PhotopicCurve(152) = 0.88496
        PhotopicCurve(153) = 0.89549
        PhotopicCurve(154) = 0.90544
        PhotopicCurve(155) = 0.91485
        PhotopicCurve(156) = 0.92373
        PhotopicCurve(157) = 0.93209
        PhotopicCurve(158) = 0.93992
        PhotopicCurve(159) = 0.94723
        PhotopicCurve(160) = 0.954
        PhotopicCurve(161) = 0.96026
        PhotopicCurve(162) = 0.96601
        PhotopicCurve(163) = 0.97126
        PhotopicCurve(164) = 0.97602
        PhotopicCurve(165) = 0.9803
        PhotopicCurve(166) = 0.98409
        PhotopicCurve(167) = 0.98748
        PhotopicCurve(168) = 0.99031
        PhotopicCurve(169) = 0.99281
        PhotopicCurve(170) = 0.99495
        PhotopicCurve(171) = 0.99671
        PhotopicCurve(172) = 0.9981
        PhotopicCurve(173) = 0.99911
        PhotopicCurve(174) = 0.99975
        PhotopicCurve(175) = 1
        PhotopicCurve(176) = 0.99986
        PhotopicCurve(177) = 0.9993
        PhotopicCurve(178) = 0.99833
        PhotopicCurve(179) = 0.9969
        PhotopicCurve(180) = 0.995
        PhotopicCurve(181) = 0.9926
        PhotopicCurve(182) = 0.98974
        PhotopicCurve(183) = 0.98644
        PhotopicCurve(184) = 0.98272
        PhotopicCurve(185) = 0.9786
        PhotopicCurve(186) = 0.97408
        PhotopicCurve(187) = 0.96917
        PhotopicCurve(188) = 0.96386
        PhotopicCurve(189) = 0.95813
        PhotopicCurve(190) = 0.952
        PhotopicCurve(191) = 0.94545
        PhotopicCurve(192) = 0.9385
        PhotopicCurve(193) = 0.93116
        PhotopicCurve(194) = 0.92346
        PhotopicCurve(195) = 0.9154
        PhotopicCurve(196) = 0.90701
        PhotopicCurve(197) = 0.89828
        PhotopicCurve(198) = 0.8892
        PhotopicCurve(199) = 0.87978
        PhotopicCurve(200) = 0.87
        PhotopicCurve(201) = 0.85986
        PhotopicCurve(202) = 0.84939
        PhotopicCurve(203) = 0.83862
        PhotopicCurve(204) = 0.82758
        PhotopicCurve(205) = 0.8163
        PhotopicCurve(206) = 0.80479
        PhotopicCurve(207) = 0.79308
        PhotopicCurve(208) = 0.78119
        PhotopicCurve(209) = 0.76915
        PhotopicCurve(210) = 0.757
        PhotopicCurve(211) = 0.74475
        PhotopicCurve(212) = 0.73242
        PhotopicCurve(213) = 0.72
        PhotopicCurve(214) = 0.7075
        PhotopicCurve(215) = 0.6949
        PhotopicCurve(216) = 0.68222
        PhotopicCurve(217) = 0.66947
        PhotopicCurve(218) = 0.65667
        PhotopicCurve(219) = 0.64384
        PhotopicCurve(220) = 0.631
        PhotopicCurve(221) = 0.61816
        PhotopicCurve(222) = 0.60531
        PhotopicCurve(223) = 0.59248
        PhotopicCurve(224) = 0.57964
        PhotopicCurve(225) = 0.5668
        PhotopicCurve(226) = 0.55396
        PhotopicCurve(227) = 0.54114
        PhotopicCurve(228) = 0.52835
        PhotopicCurve(229) = 0.51563
        PhotopicCurve(230) = 0.503
        PhotopicCurve(231) = 0.49047
        PhotopicCurve(232) = 0.47803
        PhotopicCurve(233) = 0.46568
        PhotopicCurve(234) = 0.4534
        PhotopicCurve(235) = 0.4412
        PhotopicCurve(236) = 0.42908
        PhotopicCurve(237) = 0.41704
        PhotopicCurve(238) = 0.40503
        PhotopicCurve(239) = 0.39303
        PhotopicCurve(240) = 0.381
        PhotopicCurve(241) = 0.36892
        PhotopicCurve(242) = 0.35683
        PhotopicCurve(243) = 0.34478
        PhotopicCurve(244) = 0.33282
        PhotopicCurve(245) = 0.321
        PhotopicCurve(246) = 0.30934
        PhotopicCurve(247) = 0.29785
        PhotopicCurve(248) = 0.28659
        PhotopicCurve(249) = 0.27562
        PhotopicCurve(250) = 0.265
        PhotopicCurve(251) = 0.25476
        PhotopicCurve(252) = 0.24489
        PhotopicCurve(253) = 0.23533
        PhotopicCurve(254) = 0.22605
        PhotopicCurve(255) = 0.217
        PhotopicCurve(256) = 0.20816
        PhotopicCurve(257) = 0.19955
        PhotopicCurve(258) = 0.19116
        PhotopicCurve(259) = 0.18297
        PhotopicCurve(260) = 0.175
        PhotopicCurve(261) = 0.16722
        PhotopicCurve(262) = 0.15965
        PhotopicCurve(263) = 0.15228
        PhotopicCurve(264) = 0.14513
        PhotopicCurve(265) = 0.1382
        PhotopicCurve(266) = 0.1315
        PhotopicCurve(267) = 0.12502
        PhotopicCurve(268) = 0.11878
        PhotopicCurve(269) = 0.11277
        PhotopicCurve(270) = 0.107
        PhotopicCurve(271) = 0.10148
        PhotopicCurve(272) = 0.09619
        PhotopicCurve(273) = 0.09112
        PhotopicCurve(274) = 0.08626
        PhotopicCurve(275) = 0.0816
        PhotopicCurve(276) = 0.07712
        PhotopicCurve(277) = 0.07283
        PhotopicCurve(278) = 0.06871
        PhotopicCurve(279) = 0.06477
        PhotopicCurve(280) = 0.061
        PhotopicCurve(281) = 0.0574
        PhotopicCurve(282) = 0.05396
        PhotopicCurve(283) = 0.05067
        PhotopicCurve(284) = 0.04755
        PhotopicCurve(285) = 0.04458
        PhotopicCurve(286) = 0.04176
        PhotopicCurve(287) = 0.03908
        PhotopicCurve(288) = 0.03656
        PhotopicCurve(289) = 0.0342
        PhotopicCurve(290) = 0.032
        PhotopicCurve(291) = 0.02996
        PhotopicCurve(292) = 0.02808
        PhotopicCurve(293) = 0.02633
        PhotopicCurve(294) = 0.02471
        PhotopicCurve(295) = 0.0232
        PhotopicCurve(296) = 0.0218
        PhotopicCurve(297) = 0.0205
        PhotopicCurve(298) = 0.01928
        PhotopicCurve(299) = 0.01812
        PhotopicCurve(300) = 0.017
        PhotopicCurve(301) = 0.0159
        PhotopicCurve(302) = 0.01484
        PhotopicCurve(303) = 0.01381
        PhotopicCurve(304) = 0.01283
        PhotopicCurve(305) = 0.01192
        PhotopicCurve(306) = 0.01107
        PhotopicCurve(307) = 0.01027
        PhotopicCurve(308) = 0.00953
        PhotopicCurve(309) = 0.00885
        PhotopicCurve(310) = 0.00821
        PhotopicCurve(311) = 0.00762
        PhotopicCurve(312) = 0.00709
        PhotopicCurve(313) = 0.00659
        PhotopicCurve(314) = 0.00614
        PhotopicCurve(315) = 0.00572
        PhotopicCurve(316) = 0.00534
        PhotopicCurve(317) = 0.005
        PhotopicCurve(318) = 0.00468
        PhotopicCurve(319) = 0.00438
        PhotopicCurve(320) = 0.0041
        PhotopicCurve(321) = 0.00384
        PhotopicCurve(322) = 0.00359
        PhotopicCurve(323) = 0.00335
        PhotopicCurve(324) = 0.00313
        PhotopicCurve(325) = 0.00293
        PhotopicCurve(326) = 0.00274
        PhotopicCurve(327) = 0.00256
        PhotopicCurve(328) = 0.00239
        PhotopicCurve(329) = 0.00224
        PhotopicCurve(330) = 0.00209
        PhotopicCurve(331) = 0.00195
        PhotopicCurve(332) = 0.00182
        PhotopicCurve(333) = 0.0017
        PhotopicCurve(334) = 0.00159
        PhotopicCurve(335) = 0.00148
        PhotopicCurve(336) = 0.00138
        PhotopicCurve(337) = 0.00129
        PhotopicCurve(338) = 0.0012
        PhotopicCurve(339) = 0.00112
        PhotopicCurve(340) = 0.00105
        PhotopicCurve(341) = 0.000977
        PhotopicCurve(342) = 0.000911
        PhotopicCurve(343) = 0.00085
        PhotopicCurve(344) = 0.000793
        PhotopicCurve(345) = 0.00074
        PhotopicCurve(346) = 0.00069
        PhotopicCurve(347) = 0.000643
        PhotopicCurve(348) = 0.000599
        PhotopicCurve(349) = 0.000558
        PhotopicCurve(350) = 0.00052
        PhotopicCurve(351) = 0.000484
        PhotopicCurve(352) = 0.00045
        PhotopicCurve(353) = 0.000418
        PhotopicCurve(354) = 0.000389
        PhotopicCurve(355) = 0.000361
        PhotopicCurve(356) = 0.000335
        PhotopicCurve(357) = 0.000311
        PhotopicCurve(358) = 0.000289
        PhotopicCurve(359) = 0.000268
        PhotopicCurve(360) = 0.000249
        PhotopicCurve(361) = 0.000231
        PhotopicCurve(362) = 0.000215
        PhotopicCurve(363) = 0.000199
        PhotopicCurve(364) = 0.000185
        PhotopicCurve(365) = 0.000172
        PhotopicCurve(366) = 0.00016
        PhotopicCurve(367) = 0.000149
        PhotopicCurve(368) = 0.000138
        PhotopicCurve(369) = 0.000129
        PhotopicCurve(370) = 0.00012
        PhotopicCurve(371) = 0.000112
        PhotopicCurve(372) = 0.000104
        PhotopicCurve(373) = 0.0000973
        PhotopicCurve(374) = 0.0000908
        PhotopicCurve(375) = 0.0000848
        PhotopicCurve(376) = 0.0000791
        PhotopicCurve(377) = 0.0000739
        PhotopicCurve(378) = 0.0000689
        PhotopicCurve(379) = 0.0000643
        PhotopicCurve(380) = 0.00006
        PhotopicCurve(381) = 0.000056
        PhotopicCurve(382) = 0.0000522
        PhotopicCurve(383) = 0.0000487
        PhotopicCurve(384) = 0.0000454
        PhotopicCurve(385) = 0.0000424
        PhotopicCurve(386) = 0.0000396
        PhotopicCurve(387) = 0.0000369
        PhotopicCurve(388) = 0.0000344
        PhotopicCurve(389) = 0.0000321
        PhotopicCurve(390) = 0.00003
        PhotopicCurve(391) = 0.000028
        PhotopicCurve(392) = 0.0000261
        PhotopicCurve(393) = 0.0000244
        PhotopicCurve(394) = 0.0000227
        PhotopicCurve(395) = 0.0000212
        PhotopicCurve(396) = 0.0000198
        PhotopicCurve(397) = 0.0000185
        PhotopicCurve(398) = 0.0000172
        PhotopicCurve(399) = 0.0000161
        PhotopicCurve(400) = 0.000015
        Return PhotopicCurve
    End Function

    Public Function QuantumEfficiencyWaveLen1nm(ByVal in_Lum As Single, ByVal In_J As Single, ByVal in_CellSize As Double, ByVal In_Intensity1() As Double, ByVal size As Integer) As Double

        Dim pi As Double
        Dim dQE As Double
        Dim dCv As Double
        Dim cntData As Integer
        Dim i As Integer

        Dim dCe As Double
        Dim dCn As Double
        Dim dK As Double
        Dim CellArea As Double = in_CellSize

        Dim nNumOfData As Integer = In_Intensity1.Length - 1
        'Dim OpticalPower As Double

        'dim Con_pi = 3.1415926535
        'Private Const Con_e = 1.6 * 10 ^ (-19)   
        'Private Const Con_n = 1.8                '굴절률
        'Private Const Con_h = 6.623 * 10 ^ (-34) '플랑크상수(Joul.sec)
        'Private Const Con_c = 2.998 * 10 ^ 8     '빛의속도(m/sec2)
        ' Dim In_Intensity(nNumOfData) As Single

        '        Dim k As Integer
        '        For k = 0 To nNumOfData
        '            In_Intensity(k) = CType(In_Intensity1(k), Single)
        '        Next


        '전하량
        Dim dElectronCharge As Double
        dElectronCharge = 1.6 * 10 ^ (-19)   'Coulomb

        '플랭크 상수
        Dim dPlanckConst As Double
        dPlanckConst = 6.623 * 10 ^ (-34)    '플랑크상수(Joul.sec)

        '빛의 속도
        Dim dLightSpeed As Double
        dLightSpeed = 2.998 * 10 ^ 8         '빛의속도(m/sec2)

        'initial value
        pi = 3.14159265358979
        dQE = 0.0#
        dCv = 0.0#
        'cntData = 0
        cntData = nNumOfData '100 'UBound(In_Lambda)



        '### 시감도 곡선 데이터 로드 *************************************************
        ' LoadPhotopicResponse()
        Dim LoadPhotopicResponse() As Double = LoadPhotopicResponseData()

        '### 굴절률(n)을 사용한 Cn 계산 *************************************************************
        '변경시 UI(frmDisplSet)에서 txtConstK.Text 값만 변경시켜준다.
        'Cn = n^2 * |1-root(1-1/n^2)|
        dK = CDbl(1)
        dCn = CDbl(1) 'dK ^ 2 * (Abs(1 - Sqr(1 - (1 / dK ^ 2))))


        '### Cell의 면적 *************************************************************
        'If bOneSpectrum = False Then
        '    CellArea = CDbl(mdlTestCondi.c03sCellHeight) * CDbl(mdlTestCondi.c04sCellWidth)
        'Else
        '    CellArea = CSng(frmInputSize.txtCellHeight) * CSng(frmInputSize.txtCellHeight) * CSng(frmInputSize.txtCellFillFactor) / 100
        '    bOneSpectrum = False
        'End If

        '### Calculation "F" ###
        Dim dF As Double
        dF = pi * dCn * in_Lum * CellArea


        '### Calculation "Ce" ###
        Dim i0 As Integer

        For i0 = 0 To cntData
            dCe = dCe + (380 + (i0 * size)) * In_Intensity1(i0)
        Next i0

        dCe = (dElectronCharge / (dPlanckConst * dLightSpeed)) * dCe


        '### 시감도 곡선과 스펙트럼에 대한 적분값 계산 *******************************

        'LG 화학
        'For i = 0 To cntData - 1
        '    dCv = dCv + 4 * In_Intensity(i) * In_Lambda(i)
        'Next i

        For i = 0 To cntData
            dCv = dCv + LoadPhotopicResponse(i * size) * In_Intensity1(i)
            ' dCv = dCv + m_TmpData.PhotopicCurve(i * 4) * In_Intensity(i)
        Next i

        dCv = 683 * dCv   '시감도 곡선과 스펙트럼에 대한 적분값


        '### 6.Quantum Efficiency Calculation ******************************************
        If dCv > 0 Then
            dQE = (dF * dCe) / (In_J * CellArea * dCv) * 10 ^ (-8)
        End If

        Return dQE


    End Function

#Region "XYZFunctions"
    Public CMF(450, 2) As Double
    Sub ColorMatchingFuntions()
        CMF(0, 0) = 0.001368
        CMF(0, 1) = 0.000039
        CMF(0, 2) = 0.006450001
        CMF(1, 0) = 0.00150205
        CMF(1, 1) = 0.000044
        CMF(1, 2) = 0.007083216
        CMF(2, 0) = 0.001642328
        CMF(2, 1) = 0.000049
        CMF(2, 2) = 0.007745488
        CMF(3, 0) = 0.001802382
        CMF(3, 1) = 0.000054
        CMF(3, 2) = 0.008501152
        CMF(4, 0) = 0.001995757
        CMF(4, 1) = 0.000059
        CMF(4, 2) = 0.009414544
        CMF(5, 0) = 0.002236
        CMF(5, 1) = 0.000064
        CMF(5, 2) = 0.01054999
        CMF(6, 0) = 0.002535385
        CMF(6, 1) = 0.0000752
        CMF(6, 2) = 0.0119658
        CMF(7, 0) = 0.002892603
        CMF(7, 1) = 0.0000864
        CMF(7, 2) = 0.01365587
        CMF(8, 0) = 0.003300829
        CMF(8, 1) = 0.0000976
        CMF(8, 2) = 0.01558805
        CMF(9, 0) = 0.003753236
        CMF(9, 1) = 0.0001088
        CMF(9, 2) = 0.01773015
        CMF(10, 0) = 0.004243
        CMF(10, 1) = 0.00012
        CMF(10, 2) = 0.02005001
        CMF(11, 0) = 0.004762389
        CMF(11, 1) = 0.0001394
        CMF(11, 2) = 0.02251136
        CMF(12, 0) = 0.005330048
        CMF(12, 1) = 0.0001588
        CMF(12, 2) = 0.02520288
        CMF(13, 0) = 0.005978712
        CMF(13, 1) = 0.0001782
        CMF(13, 2) = 0.02827972
        CMF(14, 0) = 0.006741117
        CMF(14, 1) = 0.0001976
        CMF(14, 2) = 0.03189704
        CMF(15, 0) = 0.00765
        CMF(15, 1) = 0.000217
        CMF(15, 2) = 0.03621
        CMF(16, 0) = 0.008751373
        CMF(16, 1) = 0.0002528
        CMF(16, 2) = 0.04143771
        CMF(17, 0) = 0.01002888
        CMF(17, 1) = 0.0002886
        CMF(17, 2) = 0.04750372
        CMF(18, 0) = 0.0114217
        CMF(18, 1) = 0.0003244
        CMF(18, 2) = 0.05411988
        CMF(19, 0) = 0.01286901
        CMF(19, 1) = 0.0003602
        CMF(19, 2) = 0.06099803
        CMF(20, 0) = 0.01431
        CMF(20, 1) = 0.000396
        CMF(20, 2) = 0.06785001
        CMF(21, 0) = 0.01570443
        CMF(21, 1) = 0.0004448
        CMF(21, 2) = 0.07448632
        CMF(22, 0) = 0.01714744
        CMF(22, 1) = 0.0004936
        CMF(22, 2) = 0.08136156
        CMF(23, 0) = 0.01878122
        CMF(23, 1) = 0.0005424
        CMF(23, 2) = 0.08915364
        CMF(24, 0) = 0.02074801
        CMF(24, 1) = 0.0005912
        CMF(24, 2) = 0.09854048
        CMF(25, 0) = 0.02319
        CMF(25, 1) = 0.00064
        CMF(25, 2) = 0.1102
        CMF(26, 0) = 0.02620736
        CMF(26, 1) = 0.000754
        CMF(26, 2) = 0.1246133
        CMF(27, 0) = 0.02978248
        CMF(27, 1) = 0.000868
        CMF(27, 2) = 0.1417017
        CMF(28, 0) = 0.03388092
        CMF(28, 1) = 0.000982
        CMF(28, 2) = 0.1613035
        CMF(29, 0) = 0.03846824
        CMF(29, 1) = 0.0011
        CMF(29, 2) = 0.1832568
        CMF(30, 0) = 0.04351
        CMF(30, 1) = 0.00121
        CMF(30, 2) = 0.2074
        CMF(31, 0) = 0.0489956
        CMF(31, 1) = 0.0014
        CMF(31, 2) = 0.2336921
        CMF(32, 0) = 0.0550226
        CMF(32, 1) = 0.0016
        CMF(32, 2) = 0.2626114
        CMF(33, 0) = 0.0617188
        CMF(33, 1) = 0.00179
        CMF(33, 2) = 0.2947746
        CMF(34, 0) = 0.069212
        CMF(34, 1) = 0.00199
        CMF(34, 2) = 0.3307985
        CMF(35, 0) = 0.07763
        CMF(35, 1) = 0.00218
        CMF(35, 2) = 0.3713
        CMF(36, 0) = 0.08695811
        CMF(36, 1) = 0.00254
        CMF(36, 2) = 0.4162091
        CMF(37, 0) = 0.09717672
        CMF(37, 1) = 0.00291
        CMF(37, 2) = 0.4654642
        CMF(38, 0) = 0.1084063
        CMF(38, 1) = 0.00327
        CMF(38, 2) = 0.5196948
        CMF(39, 0) = 0.1207672
        CMF(39, 1) = 0.00364
        CMF(39, 2) = 0.5795303
        CMF(40, 0) = 0.13438
        CMF(40, 1) = 0.004
        CMF(40, 2) = 0.6456
        CMF(41, 0) = 0.1493582
        CMF(41, 1) = 0.00466
        CMF(41, 2) = 0.7184838
        CMF(42, 0) = 0.1653957
        CMF(42, 1) = 0.00532
        CMF(42, 2) = 0.7967133
        CMF(43, 0) = 0.1819831
        CMF(43, 1) = 0.00598
        CMF(43, 2) = 0.8778459
        CMF(44, 0) = 0.198611
        CMF(44, 1) = 0.00664
        CMF(44, 2) = 0.959439
        CMF(45, 0) = 0.21477
        CMF(45, 1) = 0.0073
        CMF(45, 2) = 1.0390501
        CMF(46, 0) = 0.2301868
        CMF(46, 1) = 0.00816
        CMF(46, 2) = 1.1153673
        CMF(47, 0) = 0.2448797
        CMF(47, 1) = 0.00902
        CMF(47, 2) = 1.1884971
        CMF(48, 0) = 0.2587773
        CMF(48, 1) = 0.00988
        CMF(48, 2) = 1.2581233
        CMF(49, 0) = 0.2718079
        CMF(49, 1) = 0.01074
        CMF(49, 2) = 1.3239296
        CMF(50, 0) = 0.2839
        CMF(50, 1) = 0.0116
        CMF(50, 2) = 1.3856
        CMF(51, 0) = 0.2949438
        CMF(51, 1) = 0.01265
        CMF(51, 2) = 1.4426352
        CMF(52, 0) = 0.3048965
        CMF(52, 1) = 0.0137
        CMF(52, 2) = 1.4948035
        CMF(53, 0) = 0.3137873
        CMF(53, 1) = 0.01474
        CMF(53, 2) = 1.5421903
        CMF(54, 0) = 0.3216454
        CMF(54, 1) = 0.01579
        CMF(54, 2) = 1.5848807
        CMF(55, 0) = 0.3285
        CMF(55, 1) = 0.01684
        CMF(55, 2) = 1.62296
        CMF(56, 0) = 0.3343513
        CMF(56, 1) = 0.01807
        CMF(56, 2) = 1.6564048
        CMF(57, 0) = 0.3392101
        CMF(57, 1) = 0.0193
        CMF(57, 2) = 1.6852959
        CMF(58, 0) = 0.3431213
        CMF(58, 1) = 0.02054
        CMF(58, 2) = 1.7098745
        CMF(59, 0) = 0.3461296
        CMF(59, 1) = 0.02177
        CMF(59, 2) = 1.7303821
        CMF(60, 0) = 0.34828
        CMF(60, 1) = 0.023
        CMF(60, 2) = 1.74706
        CMF(61, 0) = 0.3495999
        CMF(61, 1) = 0.02436
        CMF(61, 2) = 1.7600446
        CMF(62, 0) = 0.3501474
        CMF(62, 1) = 0.02572
        CMF(62, 2) = 1.7696233
        CMF(63, 0) = 0.350013
        CMF(63, 1) = 0.02708
        CMF(63, 2) = 1.7762637
        CMF(64, 0) = 0.349287
        CMF(64, 1) = 0.02844
        CMF(64, 2) = 1.7804334
        CMF(65, 0) = 0.34806
        CMF(65, 1) = 0.0298
        CMF(65, 2) = 1.7826
        CMF(66, 0) = 0.3463733
        CMF(66, 1) = 0.03144
        CMF(66, 2) = 1.7829682
        CMF(67, 0) = 0.3442624
        CMF(67, 1) = 0.03308
        CMF(67, 2) = 1.7816998
        CMF(68, 0) = 0.3418088
        CMF(68, 1) = 0.03472
        CMF(68, 2) = 1.7791982
        CMF(69, 0) = 0.3390941
        CMF(69, 1) = 0.03636
        CMF(69, 2) = 1.7758671
        CMF(70, 0) = 0.3362
        CMF(70, 1) = 0.038
        CMF(70, 2) = 1.77211
        CMF(71, 0) = 0.3331977
        CMF(71, 1) = 0.04
        CMF(71, 2) = 1.7682589
        CMF(72, 0) = 0.3300411
        CMF(72, 1) = 0.042
        CMF(72, 2) = 1.764039
        CMF(73, 0) = 0.3266357
        CMF(73, 1) = 0.044
        CMF(73, 2) = 1.7589438
        CMF(74, 0) = 0.3228868
        CMF(74, 1) = 0.046
        CMF(74, 2) = 1.7524663
        CMF(75, 0) = 0.3187
        CMF(75, 1) = 0.048
        CMF(75, 2) = 1.7441
        CMF(76, 0) = 0.3140251
        CMF(76, 1) = 0.0504
        CMF(76, 2) = 1.7335595
        CMF(77, 0) = 0.308884
        CMF(77, 1) = 0.0528
        CMF(77, 2) = 1.7208581
        CMF(78, 0) = 0.3032904
        CMF(78, 1) = 0.0552
        CMF(78, 2) = 1.7059369
        CMF(79, 0) = 0.2972579
        CMF(79, 1) = 0.0576
        CMF(79, 2) = 1.6887372
        CMF(80, 0) = 0.2908
        CMF(80, 1) = 0.06
        CMF(80, 2) = 1.6692
        CMF(81, 0) = 0.2839701
        CMF(81, 1) = 0.06278
        CMF(81, 2) = 1.6475287
        CMF(82, 0) = 0.2767214
        CMF(82, 1) = 0.06556
        CMF(82, 2) = 1.6234127
        CMF(83, 0) = 0.2689178
        CMF(83, 1) = 0.06834
        CMF(83, 2) = 1.5960223
        CMF(84, 0) = 0.2604227
        CMF(84, 1) = 0.07112
        CMF(84, 2) = 1.564528
        CMF(85, 0) = 0.2511
        CMF(85, 1) = 0.0739
        CMF(85, 2) = 1.5281
        CMF(86, 0) = 0.2408475
        CMF(86, 1) = 0.07732
        CMF(86, 2) = 1.4861114
        CMF(87, 0) = 0.2298512
        CMF(87, 1) = 0.08073
        CMF(87, 2) = 1.4395215
        CMF(88, 0) = 0.2184072
        CMF(88, 1) = 0.08415
        CMF(88, 2) = 1.3898799
        CMF(89, 0) = 0.2068115
        CMF(89, 1) = 0.08756
        CMF(89, 2) = 1.3387362
        CMF(90, 0) = 0.19536
        CMF(90, 1) = 0.09098
        CMF(90, 2) = 1.28764
        CMF(91, 0) = 0.0953
        CMF(91, 2) = 1.2374223
        CMF(92, 0) = 0.1733273
        CMF(92, 1) = 0.09963
        CMF(92, 2) = 1.1878243
        CMF(93, 0) = 0.1626881
        CMF(93, 1) = 0.10395
        CMF(93, 2) = 1.1387611
        CMF(94, 0) = 0.1522833
        CMF(94, 1) = 0.10828
        CMF(94, 2) = 1.090148
        CMF(95, 0) = 0.1421
        CMF(95, 1) = 0.1126
        CMF(95, 2) = 1.0419
        CMF(96, 0) = 0.1321786
        CMF(96, 1) = 0.11788
        CMF(96, 2) = 0.9941976
        CMF(97, 0) = 0.1225696
        CMF(97, 1) = 0.12317
        CMF(97, 2) = 0.9473473
        CMF(98, 0) = 0.1132752
        CMF(98, 1) = 0.12845
        CMF(98, 2) = 0.9014531
        CMF(99, 0) = 0.1042979
        CMF(99, 1) = 0.13374
        CMF(99, 2) = 0.8566193
        CMF(100, 0) = 0.09564
        CMF(100, 1) = 0.13902
        CMF(100, 2) = 0.8129501
        CMF(101, 0) = 0.08729955
        CMF(101, 1) = 0.14508
        CMF(101, 2) = 0.7705173
        CMF(102, 0) = 0.07930804
        CMF(102, 1) = 0.15113
        CMF(102, 2) = 0.7294448
        CMF(103, 0) = 0.07171776
        CMF(103, 1) = 0.15719
        CMF(103, 2) = 0.6899136
        CMF(104, 0) = 0.06458099
        CMF(104, 1) = 0.16324
        CMF(104, 2) = 0.6521049
        CMF(105, 0) = 0.05795001
        CMF(105, 1) = 0.1693
        CMF(105, 2) = 0.6162
        CMF(106, 0) = 0.05186211
        CMF(106, 1) = 0.17704
        CMF(106, 2) = 0.5823286
        CMF(107, 0) = 0.04628152
        CMF(107, 1) = 0.18479
        CMF(107, 2) = 0.5504162
        CMF(108, 0) = 0.04115088
        CMF(108, 1) = 0.19253
        CMF(108, 2) = 0.5203376
        CMF(109, 0) = 0.03641283
        CMF(109, 1) = 0.200028
        CMF(109, 2) = 0.4919673
        CMF(110, 0) = 0.03201
        CMF(110, 1) = 0.20802
        CMF(110, 2) = 0.46518
        CMF(111, 0) = 0.0279172
        CMF(111, 1) = 0.21814
        CMF(111, 2) = 0.4399246
        CMF(112, 0) = 0.0241444
        CMF(112, 1) = 0.22825
        CMF(112, 2) = 0.4161836
        CMF(113, 0) = 0.020687
        CMF(113, 1) = 0.23837
        CMF(113, 2) = 0.3938822
        CMF(114, 0) = 0.0175404
        CMF(114, 1) = 0.24848
        CMF(114, 2) = 0.3729459
        CMF(115, 0) = 0.0147
        CMF(115, 1) = 0.2586
        CMF(115, 2) = 0.3533
        CMF(116, 0) = 0.01216179
        CMF(116, 1) = 0.27148
        CMF(116, 2) = 0.3348578
        CMF(117, 0) = 0.00991996
        CMF(117, 1) = 0.28436
        CMF(117, 2) = 0.3175521
        CMF(118, 0) = 0.00796724
        CMF(118, 1) = 0.29724
        CMF(118, 2) = 0.3013375
        CMF(119, 0) = 0.006296346
        CMF(119, 1) = 0.31012
        CMF(119, 2) = 0.2861686
        CMF(120, 0) = 0.0049
        CMF(120, 1) = 0.323
        CMF(120, 2) = 0.272
        CMF(121, 0) = 0.003777173
        CMF(121, 1) = 0.33986
        CMF(121, 2) = 0.2588171
        CMF(122, 0) = 0.00294532
        CMF(122, 1) = 0.35672
        CMF(122, 2) = 0.2464838
        CMF(123, 0) = 0.00242488
        CMF(123, 1) = 0.37358
        CMF(123, 2) = 0.2347718
        CMF(124, 0) = 0.002236293
        CMF(124, 1) = 0.39044
        CMF(124, 2) = 0.2234533
        CMF(125, 0) = 0.0024
        CMF(125, 1) = 0.4073
        CMF(125, 2) = 0.2123
        CMF(126, 0) = 0.00292552
        CMF(126, 1) = 0.42644
        CMF(126, 2) = 0.2011692
        CMF(127, 0) = 0.00383656
        CMF(127, 1) = 0.44558
        CMF(127, 2) = 0.1901196
        CMF(128, 0) = 0.00517484
        CMF(128, 1) = 0.46472
        CMF(128, 2) = 0.1792254
        CMF(129, 0) = 0.00698208
        CMF(129, 1) = 0.48386
        CMF(129, 2) = 0.1685608
        CMF(130, 0) = 0.0093
        CMF(130, 1) = 0.503
        CMF(130, 2) = 0.1582
        CMF(131, 0) = 0.01214949
        CMF(131, 1) = 0.52404
        CMF(131, 2) = 0.1481383
        CMF(132, 0) = 0.01553588
        CMF(132, 1) = 0.54508
        CMF(132, 2) = 0.1383758
        CMF(133, 0) = 0.01947752
        CMF(133, 1) = 0.56612
        CMF(133, 2) = 0.1289942
        CMF(134, 0) = 0.02399277
        CMF(134, 1) = 0.58716
        CMF(134, 2) = 0.1200751
        CMF(135, 0) = 0.0291
        CMF(135, 1) = 0.6082
        CMF(135, 2) = 0.1117
        CMF(136, 0) = 0.03481485
        CMF(136, 1) = 0.62856
        CMF(136, 2) = 0.1039048
        CMF(137, 0) = 0.04112016
        CMF(137, 1) = 0.64892
        CMF(137, 2) = 0.09666748
        CMF(138, 0) = 0.04798504
        CMF(138, 1) = 0.66928
        CMF(138, 2) = 0.08998272
        CMF(139, 0) = 0.05537861
        CMF(139, 1) = 0.68964
        CMF(139, 2) = 0.08384531
        CMF(140, 0) = 0.06327
        CMF(140, 1) = 0.71
        CMF(140, 2) = 0.07824999
        CMF(141, 0) = 0.07163501
        CMF(141, 1) = 0.72664
        CMF(141, 2) = 0.07320899
        CMF(142, 0) = 0.08046224
        CMF(142, 1) = 0.74328
        CMF(142, 2) = 0.06867816
        CMF(143, 0) = 0.08973996
        CMF(143, 1) = 0.75992
        CMF(143, 2) = 0.06456784
        CMF(144, 0) = 0.09945645
        CMF(144, 1) = 0.77656
        CMF(144, 2) = 0.06078835
        CMF(145, 0) = 0.1096
        CMF(145, 1) = 0.7932
        CMF(145, 2) = 0.05725001
        CMF(146, 0) = 0.1201674
        CMF(146, 1) = 0.80696
        CMF(146, 2) = 0.05390435
        CMF(147, 0) = 0.1311145
        CMF(147, 1) = 0.82072
        CMF(147, 2) = 0.05074664
        CMF(148, 0) = 0.1423679
        CMF(148, 1) = 0.83448
        CMF(148, 2) = 0.04775276
        CMF(149, 0) = 0.1538542
        CMF(149, 1) = 0.84824
        CMF(149, 2) = 0.04489859
        CMF(150, 0) = 0.1655
        CMF(150, 1) = 0.862
        CMF(150, 2) = 0.04216
        CMF(151, 0) = 0.1772571
        CMF(151, 1) = 0.87257
        CMF(151, 2) = 0.03950728
        CMF(152, 0) = 0.18914
        CMF(152, 1) = 0.88314
        CMF(152, 2) = 0.03693564
        CMF(153, 0) = 0.2011694
        CMF(153, 1) = 0.89371
        CMF(153, 2) = 0.03445836
        CMF(154, 0) = 0.2133658
        CMF(154, 1) = 0.90428
        CMF(154, 2) = 0.03208872
        CMF(155, 0) = 0.2257499
        CMF(155, 1) = 0.91485
        CMF(155, 2) = 0.02984
        CMF(156, 0) = 0.2383209
        CMF(156, 1) = 0.92268
        CMF(156, 2) = 0.02771181
        CMF(157, 0) = 0.2510668
        CMF(157, 1) = 0.93051
        CMF(157, 2) = 0.02569444
        CMF(158, 0) = 0.2639922
        CMF(158, 1) = 0.93834
        CMF(158, 2) = 0.02378716
        CMF(159, 0) = 0.2771017
        CMF(159, 1) = 0.94617
        CMF(159, 2) = 0.02198925
        CMF(160, 0) = 0.2904
        CMF(160, 1) = 0.954
        CMF(160, 2) = 0.0203
        CMF(161, 0) = 0.3038912
        CMF(161, 1) = 0.95926
        CMF(161, 2) = 0.01871805
        CMF(162, 0) = 0.3175726
        CMF(162, 1) = 0.96452
        CMF(162, 2) = 0.01724036
        CMF(163, 0) = 0.3314384
        CMF(163, 1) = 0.96978
        CMF(163, 2) = 0.01586364
        CMF(164, 0) = 0.3454828
        CMF(164, 1) = 0.97504
        CMF(164, 2) = 0.01458461
        CMF(165, 0) = 0.3597
        CMF(165, 1) = 0.9803
        CMF(165, 2) = 0.0134
        CMF(166, 0) = 0.3740839
        CMF(166, 1) = 0.98323
        CMF(166, 2) = 0.01230723
        CMF(167, 0) = 0.3886396
        CMF(167, 1) = 0.98616
        CMF(167, 2) = 0.01130188
        CMF(168, 0) = 0.4033784
        CMF(168, 1) = 0.98909
        CMF(168, 2) = 0.01037792
        CMF(169, 0) = 0.4183115
        CMF(169, 1) = 0.99202
        CMF(169, 2) = 0.009529306
        CMF(170, 0) = 0.4334499
        CMF(170, 1) = 0.99495
        CMF(170, 2) = 0.008749999
        CMF(171, 0) = 0.4487953
        CMF(171, 1) = 0.99596
        CMF(171, 2) = 0.0080352
        CMF(172, 0) = 0.464336
        CMF(172, 1) = 0.99697
        CMF(172, 2) = 0.0073816
        CMF(173, 0) = 0.480064
        CMF(173, 1) = 0.99798
        CMF(173, 2) = 0.0067854
        CMF(174, 0) = 0.4959713
        CMF(174, 1) = 0.99899
        CMF(174, 2) = 0.0062428
        CMF(175, 0) = 0.5120501
        CMF(175, 1) = 1
        CMF(175, 2) = 0.005749999
        CMF(176, 0) = 0.5282959
        CMF(176, 1) = 0.999
        CMF(176, 2) = 0.0053036
        CMF(177, 0) = 0.5446916
        CMF(177, 1) = 0.998
        CMF(177, 2) = 0.0048998
        CMF(178, 0) = 0.5612094
        CMF(178, 1) = 0.997
        CMF(178, 2) = 0.0045342
        CMF(179, 0) = 0.5778215
        CMF(179, 1) = 0.996
        CMF(179, 2) = 0.0042024
        CMF(180, 0) = 0.5945
        CMF(180, 1) = 0.995
        CMF(180, 2) = 0.0039
        CMF(181, 0) = 0.6112209
        CMF(181, 1) = 0.99172
        CMF(181, 2) = 0.0036232
        CMF(182, 0) = 0.6279758
        CMF(182, 1) = 0.98844
        CMF(182, 2) = 0.0033706
        CMF(183, 0) = 0.6447602
        CMF(183, 1) = 0.98516
        CMF(183, 2) = 0.0031414
        CMF(184, 0) = 0.6615697
        CMF(184, 1) = 0.98188
        CMF(184, 2) = 0.0029348
        CMF(185, 0) = 0.6784
        CMF(185, 1) = 0.9786
        CMF(185, 2) = 0.002749999
        CMF(186, 0) = 0.6952392
        CMF(186, 1) = 0.97328
        CMF(186, 2) = 0.0025852
        CMF(187, 0) = 0.7120586
        CMF(187, 1) = 0.96796
        CMF(187, 2) = 0.0024386
        CMF(188, 0) = 0.7288284
        CMF(188, 1) = 0.96264
        CMF(188, 2) = 0.0023094
        CMF(189, 0) = 0.7455188
        CMF(189, 1) = 0.95732
        CMF(189, 2) = 0.0021968
        CMF(190, 0) = 0.7621
        CMF(190, 1) = 0.952
        CMF(190, 2) = 0.0021
        CMF(191, 0) = 0.7785432
        CMF(191, 1) = 0.94468
        CMF(191, 2) = 0.002017733
        CMF(192, 0) = 0.7948256
        CMF(192, 1) = 0.93736
        CMF(192, 2) = 0.0019482
        CMF(193, 0) = 0.8109264
        CMF(193, 1) = 0.93004
        CMF(193, 2) = 0.0018898
        CMF(194, 0) = 0.8268248
        CMF(194, 1) = 0.92272
        CMF(194, 2) = 0.001840933
        CMF(195, 0) = 0.8425
        CMF(195, 1) = 0.9154
        CMF(195, 2) = 0.0018
        CMF(196, 0) = 0.8579325
        CMF(196, 1) = 0.90632
        CMF(196, 2) = 0.001766267
        CMF(197, 0) = 0.8730816
        CMF(197, 1) = 0.89724
        CMF(197, 2) = 0.0017378
        CMF(198, 0) = 0.8878944
        CMF(198, 1) = 0.88816
        CMF(198, 2) = 0.0017112
        CMF(199, 0) = 0.9023181
        CMF(199, 1) = 0.87908
        CMF(199, 2) = 0.001683067
        CMF(200, 0) = 0.9163
        CMF(200, 1) = 0.87
        CMF(200, 2) = 0.001650001
        CMF(201, 0) = 0.9297995
        CMF(201, 1) = 0.85926
        CMF(201, 2) = 0.001610133
        CMF(202, 0) = 0.9427984
        CMF(202, 1) = 0.84852
        CMF(202, 2) = 0.0015644
        CMF(203, 0) = 0.9552776
        CMF(203, 1) = 0.83778
        CMF(203, 2) = 0.0015136
        CMF(204, 0) = 0.9672179
        CMF(204, 1) = 0.82704
        CMF(204, 2) = 0.001458533
        CMF(205, 0) = 0.9786
        CMF(205, 1) = 0.8163
        CMF(205, 2) = 0.0014
        CMF(206, 0) = 0.9893856
        CMF(206, 1) = 0.80444
        CMF(206, 2) = 0.001336667
        CMF(207, 0) = 0.9995488
        CMF(207, 1) = 0.79258
        CMF(207, 2) = 0.00127
        CMF(208, 0) = 1.0090892
        CMF(208, 1) = 0.78072
        CMF(208, 2) = 0.001205
        CMF(209, 0) = 1.0180064
        CMF(209, 1) = 0.76886
        CMF(209, 2) = 0.001146667
        CMF(210, 0) = 1.0263
        CMF(210, 1) = 0.757
        CMF(210, 2) = 0.0011
        CMF(211, 0) = 1.0339827
        CMF(211, 1) = 0.74458
        CMF(211, 2) = 0.0010688
        CMF(212, 0) = 1.040986
        CMF(212, 1) = 0.73216
        CMF(212, 2) = 0.0010494
        CMF(213, 0) = 1.047188
        CMF(213, 1) = 0.71974
        CMF(213, 2) = 0.0010356
        CMF(214, 0) = 1.0524667
        CMF(214, 1) = 0.70732
        CMF(214, 2) = 0.0010212
        CMF(215, 0) = 1.0567
        CMF(215, 1) = 0.6949
        CMF(215, 2) = 0.001
        CMF(216, 0) = 1.0597944
        CMF(216, 1) = 0.68212
        CMF(216, 2) = 0.00096864
        CMF(217, 0) = 1.0617992
        CMF(217, 1) = 0.66934
        CMF(217, 2) = 0.00092992
        CMF(218, 0) = 1.0628068
        CMF(218, 1) = 0.65656
        CMF(218, 2) = 0.00088688
        CMF(219, 0) = 1.0629096
        CMF(219, 1) = 0.64378
        CMF(219, 2) = 0.00084256
        CMF(220, 0) = 1.0622
        CMF(220, 1) = 0.631
        CMF(220, 2) = 0.0008
        CMF(221, 0) = 1.0607352
        CMF(221, 1) = 0.61816
        CMF(221, 2) = 0.00076096
        CMF(222, 0) = 1.0584436
        CMF(222, 1) = 0.60532
        CMF(222, 2) = 0.00072368
        CMF(223, 0) = 1.0552244
        CMF(223, 1) = 0.59248
        CMF(223, 2) = 0.00068592
        CMF(224, 0) = 1.0509768
        CMF(224, 1) = 0.57964
        CMF(224, 2) = 0.00064544
        CMF(225, 0) = 1.0456
        CMF(225, 1) = 0.5668
        CMF(225, 2) = 0.0006
        CMF(226, 0) = 1.0390369
        CMF(226, 1) = 0.55404
        CMF(226, 2) = 0.000547867
        CMF(227, 0) = 1.0313608
        CMF(227, 1) = 0.54128
        CMF(227, 2) = 0.0004916
        CMF(228, 0) = 1.0226662
        CMF(228, 1) = 0.52852
        CMF(228, 2) = 0.0004354
        CMF(229, 0) = 1.0130477
        CMF(229, 1) = 0.51576
        CMF(229, 2) = 0.000383467
        CMF(230, 0) = 1.0026
        CMF(230, 1) = 0.503
        CMF(230, 2) = 0.00034
        CMF(231, 0) = 0.9913675
        CMF(231, 1) = 0.49064
        CMF(231, 2) = 0.000307253
        CMF(232, 0) = 0.9793314
        CMF(232, 1) = 0.47828
        CMF(232, 2) = 0.00028316
        CMF(233, 0) = 0.9664916
        CMF(233, 1) = 0.46592
        CMF(233, 2) = 0.00026544
        CMF(234, 0) = 0.9528479
        CMF(234, 1) = 0.45356
        CMF(234, 2) = 0.000251813
        CMF(235, 0) = 0.9384
        CMF(235, 1) = 0.4412
        CMF(235, 2) = 0.00024
        CMF(236, 0) = 0.923194
        CMF(236, 1) = 0.42916
        CMF(236, 2) = 0.000229547
        CMF(237, 0) = 0.907244
        CMF(237, 1) = 0.41712
        CMF(237, 2) = 0.00022064
        CMF(238, 0) = 0.890502
        CMF(238, 1) = 0.40508
        CMF(238, 2) = 0.00021196
        CMF(239, 0) = 0.87292
        CMF(239, 1) = 0.39304
        CMF(239, 2) = 0.000202187
        CMF(240, 0) = 0.8544499
        CMF(240, 1) = 0.381
        CMF(240, 2) = 0.00019
        CMF(241, 0) = 0.835084
        CMF(241, 1) = 0.369
        CMF(241, 2) = 0.000174213
        CMF(242, 0) = 0.814946
        CMF(242, 1) = 0.357
        CMF(242, 2) = 0.00015564
        CMF(243, 0) = 0.794186
        CMF(243, 1) = 0.345
        CMF(243, 2) = 0.00013596
        CMF(244, 0) = 0.772954
        CMF(244, 1) = 0.333
        CMF(244, 2) = 0.000116853
        CMF(245, 0) = 0.7514
        CMF(245, 1) = 0.321
        CMF(245, 2) = 0.0001
        CMF(246, 0) = 0.7295836
        CMF(246, 1) = 0.3098
        CMF(246, 2) = 0.0000861333
        CMF(247, 0) = 0.7075888
        CMF(247, 1) = 0.2986
        CMF(247, 2) = 0.0000746
        CMF(248, 0) = 0.6856022
        CMF(248, 1) = 0.2874
        CMF(248, 2) = 0.000065
        CMF(249, 0) = 0.6638104
        CMF(249, 1) = 0.2762
        CMF(249, 2) = 0.0000569333
        CMF(250, 0) = 0.6424
        CMF(250, 1) = 0.265
        CMF(250, 2) = 0.00005
        CMF(251, 0) = 0.6215149
        CMF(251, 1) = 0.2554
        CMF(251, 2) = 0.00004416
        CMF(252, 0) = 0.6011138
        CMF(252, 1) = 0.2458
        CMF(252, 2) = 0.00003948
        CMF(253, 0) = 0.5811052
        CMF(253, 1) = 0.2362
        CMF(253, 2) = 0.00003572
        CMF(254, 0) = 0.5613977
        CMF(254, 1) = 0.2266
        CMF(254, 2) = 0.00003264
        CMF(255, 0) = 0.5419
        CMF(255, 1) = 0.217
        CMF(255, 2) = 0.00003
        CMF(256, 0) = 0.5225995
        CMF(256, 1) = 0.2086
        CMF(256, 2) = 0.0000276533
        CMF(257, 0) = 0.5035464
        CMF(257, 1) = 0.2002
        CMF(257, 2) = 0.00002556
        CMF(258, 0) = 0.4847436
        CMF(258, 1) = 0.1918
        CMF(258, 2) = 0.00002364
        CMF(259, 0) = 0.4661939
        CMF(259, 1) = 0.1834
        CMF(259, 2) = 0.0000218133
        CMF(260, 0) = 0.4479
        CMF(260, 1) = 0.175
        CMF(260, 2) = 0.00002
        CMF(261, 0) = 0.4298613
        CMF(261, 1) = 0.16764
        CMF(261, 2) = 0.0000181333
        CMF(262, 0) = 0.412098
        CMF(262, 1) = 0.16028
        CMF(262, 2) = 0.0000162
        CMF(263, 0) = 0.394644
        CMF(263, 1) = 0.15292
        CMF(263, 2) = 0.0000142
        CMF(264, 0) = 0.3775333
        CMF(264, 1) = 0.14556
        CMF(264, 2) = 0.0000121333
        CMF(265, 0) = 0.3608
        CMF(265, 1) = 0.1382
        CMF(265, 2) = 0.00001
        CMF(266, 0) = 0.3444563
        CMF(266, 1) = 0.13196
        CMF(266, 2) = 0.00000773333
        CMF(267, 0) = 0.3285168
        CMF(267, 1) = 0.12572
        CMF(267, 2) = 0.0000054
        CMF(268, 0) = 0.3130192
        CMF(268, 1) = 0.11948
        CMF(268, 2) = 0.0000032
        CMF(269, 0) = 0.2980011
        CMF(269, 1) = 0.11324
        CMF(269, 2) = 0.00000133333
        CMF(270, 0) = 0.2835
        CMF(270, 1) = 0.107
        CMF(270, 2) = 0
        CMF(271, 0) = 0.2695448
        CMF(271, 1) = 0.10192
        CMF(271, 2) = 0
        CMF(272, 0) = 0.2561184
        CMF(272, 1) = 0.09684
        CMF(272, 2) = 0
        CMF(273, 0) = 0.2431896
        CMF(273, 1) = 0.09176
        CMF(273, 2) = 0
        CMF(274, 0) = 0.2307272
        CMF(274, 1) = 0.08668
        CMF(274, 2) = 0
        CMF(275, 0) = 0.2187
        CMF(275, 1) = 0.0816
        CMF(275, 2) = 0
        CMF(276, 0) = 0.2070971
        CMF(276, 1) = 0.07748
        CMF(276, 2) = 0
        CMF(277, 0) = 0.1959232
        CMF(277, 1) = 0.07336
        CMF(277, 2) = 0
        CMF(278, 0) = 0.1851708
        CMF(278, 1) = 0.06924
        CMF(278, 2) = 0
        CMF(279, 0) = 0.1748323
        CMF(279, 1) = 0.06512
        CMF(279, 2) = 0
        CMF(280, 0) = 0.1649
        CMF(280, 1) = 0.061
        CMF(280, 2) = 0
        CMF(281, 0) = 0.1553667
        CMF(281, 1) = 0.05772
        CMF(281, 2) = 0
        CMF(282, 0) = 0.14623
        CMF(282, 1) = 0.05443
        CMF(282, 2) = 0
        CMF(283, 0) = 0.13749
        CMF(283, 1) = 0.05115
        CMF(283, 2) = 0
        CMF(284, 0) = 0.1291467
        CMF(284, 1) = 0.04786
        CMF(284, 2) = 0
        CMF(285, 0) = 0.1212
        CMF(285, 1) = 0.04458
        CMF(285, 2) = 0
        CMF(286, 0) = 0.1136397
        CMF(286, 1) = 0.04206
        CMF(286, 2) = 0
        CMF(287, 0) = 0.106465
        CMF(287, 1) = 0.03955
        CMF(287, 2) = 0
        CMF(288, 0) = 0.09969044
        CMF(288, 1) = 0.03703
        CMF(288, 2) = 0
        CMF(289, 0) = 0.09333061
        CMF(289, 1) = 0.03452
        CMF(289, 2) = 0
        CMF(290, 0) = 0.0874
        CMF(290, 1) = 0.032
        CMF(290, 2) = 0
        CMF(291, 0) = 0.08190096
        CMF(291, 1) = 0.03024
        CMF(291, 2) = 0
        CMF(292, 0) = 0.07680428
        CMF(292, 1) = 0.02848
        CMF(292, 2) = 0
        CMF(293, 0) = 0.07207712
        CMF(293, 1) = 0.02672
        CMF(293, 2) = 0
        CMF(294, 0) = 0.06768664
        CMF(294, 1) = 0.02496
        CMF(294, 2) = 0
        CMF(295, 0) = 0.0636
        CMF(295, 1) = 0.0232
        CMF(295, 2) = 0
        CMF(296, 0) = 0.05980685
        CMF(296, 1) = 0.02196
        CMF(296, 2) = 0
        CMF(297, 0) = 0.05628216
        CMF(297, 1) = 0.02072
        CMF(297, 2) = 0
        CMF(298, 0) = 0.05297104
        CMF(298, 1) = 0.01948
        CMF(298, 2) = 0
        CMF(299, 0) = 0.04981861
        CMF(299, 1) = 0.01824
        CMF(299, 2) = 0
        CMF(300, 0) = 0.04677
        CMF(300, 1) = 0.017
        CMF(300, 2) = 0
        CMF(301, 0) = 0.04378405
        CMF(301, 1) = 0.01598
        CMF(301, 2) = 0
        CMF(302, 0) = 0.04087536
        CMF(302, 1) = 0.01497
        CMF(302, 2) = 0
        CMF(303, 0) = 0.03807264
        CMF(303, 1) = 0.01395
        CMF(303, 2) = 0
        CMF(304, 0) = 0.03540461
        CMF(304, 1) = 0.01294
        CMF(304, 2) = 0
        CMF(305, 0) = 0.0329
        CMF(305, 1) = 0.01192
        CMF(305, 2) = 0
        CMF(306, 0) = 0.03056419
        CMF(306, 1) = 0.01118
        CMF(306, 2) = 0
        CMF(307, 0) = 0.02838056
        CMF(307, 1) = 0.01044
        CMF(307, 2) = 0
        CMF(308, 0) = 0.02634484
        CMF(308, 1) = 0.00969
        CMF(308, 2) = 0
        CMF(309, 0) = 0.02445275
        CMF(309, 1) = 0.00895
        CMF(309, 2) = 0
        CMF(310, 0) = 0.0227
        CMF(310, 1) = 0.00821
        CMF(310, 2) = 0
        CMF(311, 0) = 0.02108429
        CMF(311, 1) = 0.00771
        CMF(311, 2) = 0
        CMF(312, 0) = 0.01959988
        CMF(312, 1) = 0.00722
        CMF(312, 2) = 0
        CMF(313, 0) = 0.01823732
        CMF(313, 1) = 0.00672
        CMF(313, 2) = 0
        CMF(314, 0) = 0.01698717
        CMF(314, 1) = 0.00622
        CMF(314, 2) = 0
        CMF(315, 0) = 0.01584
        CMF(315, 1) = 0.005723
        CMF(315, 2) = 0
        CMF(316, 0) = 0.01479064
        CMF(316, 1) = 0.0054
        CMF(316, 2) = 0
        CMF(317, 0) = 0.01383132
        CMF(317, 1) = 0.00507
        CMF(317, 2) = 0
        CMF(318, 0) = 0.01294868
        CMF(318, 1) = 0.00475
        CMF(318, 2) = 0
        CMF(319, 0) = 0.0121292
        CMF(319, 1) = 0.00443
        CMF(319, 2) = 0
        CMF(320, 0) = 0.01135916
        CMF(320, 1) = 0.004102
        CMF(320, 2) = 0
        CMF(321, 0) = 0.01062935
        CMF(321, 1) = 0.00387
        CMF(321, 2) = 0
        CMF(322, 0) = 0.009938846
        CMF(322, 1) = 0.00363
        CMF(322, 2) = 0
        CMF(323, 0) = 0.009288422
        CMF(323, 1) = 0.0034
        CMF(323, 2) = 0
        CMF(324, 0) = 0.008678854
        CMF(324, 1) = 0.00316
        CMF(324, 2) = 0
        CMF(325, 0) = 0.008110916
        CMF(325, 1) = 0.002929
        CMF(325, 2) = 0
        CMF(326, 0) = 0.007582388
        CMF(326, 1) = 0.00276
        CMF(326, 2) = 0
        CMF(327, 0) = 0.007088746
        CMF(327, 1) = 0.00259
        CMF(327, 2) = 0
        CMF(328, 0) = 0.006627313
        CMF(328, 1) = 0.00243
        CMF(328, 2) = 0
        CMF(329, 0) = 0.006195408
        CMF(329, 1) = 0.00226
        CMF(329, 2) = 0
        CMF(330, 0) = 0.005790346
        CMF(330, 1) = 0.002091
        CMF(330, 2) = 0
        CMF(331, 0) = 0.005409826
        CMF(331, 1) = 0.00197
        CMF(331, 2) = 0
        CMF(332, 0) = 0.005052583
        CMF(332, 1) = 0.00185
        CMF(332, 2) = 0
        CMF(333, 0) = 0.004717512
        CMF(333, 1) = 0.00173
        CMF(333, 2) = 0
        CMF(334, 0) = 0.004403507
        CMF(334, 1) = 0.00161
        CMF(334, 2) = 0
        CMF(335, 0) = 0.004109457
        CMF(335, 1) = 0.001484
        CMF(335, 2) = 0
        CMF(336, 0) = 0.003833913
        CMF(336, 1) = 0.0014
        CMF(336, 2) = 0
        CMF(337, 0) = 0.003575748
        CMF(337, 1) = 0.00131
        CMF(337, 2) = 0
        CMF(338, 0) = 0.003334342
        CMF(338, 1) = 0.00122
        CMF(338, 2) = 0
        CMF(339, 0) = 0.003109075
        CMF(339, 1) = 0.00113
        CMF(339, 2) = 0
        CMF(340, 0) = 0.002899327
        CMF(340, 1) = 0.001047
        CMF(340, 2) = 0
        CMF(341, 0) = 0.002704348
        CMF(341, 1) = 0.000986
        CMF(341, 2) = 0
        CMF(342, 0) = 0.00252302
        CMF(342, 1) = 0.000924
        CMF(342, 2) = 0
        CMF(343, 0) = 0.002354168
        CMF(343, 1) = 0.000863
        CMF(343, 2) = 0
        CMF(344, 0) = 0.002196616
        CMF(344, 1) = 0.000801
        CMF(344, 2) = 0
        CMF(345, 0) = 0.00204919
        CMF(345, 1) = 0.00074
        CMF(345, 2) = 0
        CMF(346, 0) = 0.00191096
        CMF(346, 1) = 0.000696
        CMF(346, 2) = 0
        CMF(347, 0) = 0.001781438
        CMF(347, 1) = 0.000652
        CMF(347, 2) = 0
        CMF(348, 0) = 0.00166011
        CMF(348, 1) = 0.000608
        CMF(348, 2) = 0
        CMF(349, 0) = 0.001546459
        CMF(349, 1) = 0.000564
        CMF(349, 2) = 0
        CMF(350, 0) = 0.001439971
        CMF(350, 1) = 0.00052
        CMF(350, 2) = 0
        CMF(351, 0) = 0.001340042
        CMF(351, 1) = 0.000488
        CMF(351, 2) = 0
        CMF(352, 0) = 0.001246275
        CMF(352, 1) = 0.000456
        CMF(352, 2) = 0
        CMF(353, 0) = 0.001158471
        CMF(353, 1) = 0.000125
        CMF(353, 2) = 0
        CMF(354, 0) = 0.00107643
        CMF(354, 1) = 0.000393
        CMF(354, 2) = 0
        CMF(355, 0) = 0.000999949
        CMF(355, 1) = 0.0003611
        CMF(355, 2) = 0
        CMF(356, 0) = 0.000928736
        CMF(356, 1) = 0.000339
        CMF(356, 2) = 0
        CMF(357, 0) = 0.000862433
        CMF(357, 1) = 0.000316
        CMF(357, 2) = 0
        CMF(358, 0) = 0.00080075
        CMF(358, 1) = 0.000294
        CMF(358, 2) = 0
        CMF(359, 0) = 0.000743396
        CMF(359, 1) = 0.000271
        CMF(359, 2) = 0
        CMF(360, 0) = 0.000690079
        CMF(360, 1) = 0.0002492
        CMF(360, 2) = 0
        CMF(361, 0) = 0.000640516
        CMF(361, 1) = 0.000234
        CMF(361, 2) = 0
        CMF(362, 0) = 0.000594502
        CMF(362, 1) = 0.000218
        CMF(362, 2) = 0
        CMF(363, 0) = 0.000551865
        CMF(363, 1) = 0.000203
        CMF(363, 2) = 0
        CMF(364, 0) = 0.000512429
        CMF(364, 1) = 0.000187
        CMF(364, 2) = 0
        CMF(365, 0) = 0.000476021
        CMF(365, 1) = 0.0001719
        CMF(365, 2) = 0
        CMF(366, 0) = 0.000442454
        CMF(366, 1) = 0.000162
        CMF(366, 2) = 0
        CMF(367, 0) = 0.000411512
        CMF(367, 1) = 0.000151
        CMF(367, 2) = 0
        CMF(368, 0) = 0.000382981
        CMF(368, 1) = 0.000141
        CMF(368, 2) = 0
        CMF(369, 0) = 0.000356649
        CMF(369, 1) = 0.00013
        CMF(369, 2) = 0
        CMF(370, 0) = 0.000332301
        CMF(370, 1) = 0.00012
        CMF(370, 2) = 0
        CMF(371, 0) = 0.000309759
        CMF(371, 1) = 0.000113
        CMF(371, 2) = 0
        CMF(372, 0) = 0.000288887
        CMF(372, 1) = 0.000106
        CMF(372, 2) = 0
        CMF(373, 0) = 0.000269539
        CMF(373, 1) = 0.000099
        CMF(373, 2) = 0
        CMF(374, 0) = 0.000251568
        CMF(374, 1) = 0.000092
        CMF(374, 2) = 0
        CMF(375, 0) = 0.000234826
        CMF(375, 1) = 0.0000848
        CMF(375, 2) = 0
        CMF(376, 0) = 0.000219171
        CMF(376, 1) = 0.00008
        CMF(376, 2) = 0
        CMF(377, 0) = 0.000204526
        CMF(377, 1) = 0.000075
        CMF(377, 2) = 0
        CMF(378, 0) = 0.000190841
        CMF(378, 1) = 0.00007
        CMF(378, 2) = 0
        CMF(379, 0) = 0.000178065
        CMF(379, 1) = 0.000065
        CMF(379, 2) = 0
        CMF(380, 0) = 0.000166151
        CMF(380, 1) = 0.00006
        CMF(380, 2) = 0
        CMF(381, 0) = 0.000155024
        CMF(381, 1) = 0.0000564
        CMF(381, 2) = 0
        CMF(382, 0) = 0.000144622
        CMF(382, 1) = 0.0000528
        CMF(382, 2) = 0
        CMF(383, 0) = 0.00013491
        CMF(383, 1) = 0.0000492
        CMF(383, 2) = 0
        CMF(384, 0) = 0.000125852
        CMF(384, 1) = 0.0000456
        CMF(384, 2) = 0
        CMF(385, 0) = 0.000117413
        CMF(385, 1) = 0.0000424
        CMF(385, 2) = 0
        CMF(386, 0) = 0.000109552
        CMF(386, 1) = 0.0000396
        CMF(386, 2) = 0
        CMF(387, 0) = 0.000102225
        CMF(387, 1) = 0.0000372
        CMF(387, 2) = 0
        CMF(388, 0) = 0.0000953945
        CMF(388, 1) = 0.0000348
        CMF(388, 2) = 0
        CMF(389, 0) = 0.0000890239
        CMF(389, 1) = 0.0000324
        CMF(389, 2) = 0
        CMF(390, 0) = 0.0000830753
        CMF(390, 1) = 0.00003
        CMF(390, 2) = 0
        CMF(391, 0) = 0.0000775127
        CMF(391, 1) = 0.0000282
        CMF(391, 2) = 0
        CMF(392, 0) = 0.000072313
        CMF(392, 1) = 0.0000264
        CMF(392, 2) = 0
        CMF(393, 0) = 0.0000674578
        CMF(393, 1) = 0.0000246
        CMF(393, 2) = 0
        CMF(394, 0) = 0.0000629284
        CMF(394, 1) = 0.0000228
        CMF(394, 2) = 0
        CMF(395, 0) = 0.0000587065
        CMF(395, 1) = 0.0000212
        CMF(395, 2) = 0
        CMF(396, 0) = 0.0000547703
        CMF(396, 1) = 0.0000198
        CMF(396, 2) = 0
        CMF(397, 0) = 0.0000510992
        CMF(397, 1) = 0.0000186
        CMF(397, 2) = 0
        CMF(398, 0) = 0.0000476765
        CMF(398, 1) = 0.0000174
        CMF(398, 2) = 0
        CMF(399, 0) = 0.0000444857
        CMF(399, 1) = 0.0000162
        CMF(399, 2) = 0
        CMF(400, 0) = 0.0000415099
        CMF(400, 1) = 0.00001499
        CMF(400, 2) = 0
        CMF(401, 0) = 0.0000387332
        CMF(401, 1) = 0.0000139873
        CMF(401, 2) = 0
        CMF(402, 0) = 0.000036142
        CMF(402, 1) = 0.0000130516
        CMF(402, 2) = 0
        CMF(403, 0) = 0.0000337235
        CMF(403, 1) = 0.0000121782
        CMF(403, 2) = 0
        CMF(404, 0) = 0.0000314649
        CMF(404, 1) = 0.0000113625
        CMF(404, 2) = 0
        CMF(405, 0) = 0.0000293533
        CMF(405, 1) = 0.0000106
        CMF(405, 2) = 0
        CMF(406, 0) = 0.0000273757
        CMF(406, 1) = 0.00000988588
        CMF(406, 2) = 0
        CMF(407, 0) = 0.0000255243
        CMF(407, 1) = 0.0000092173
        CMF(407, 2) = 0
        CMF(408, 0) = 0.0000237938
        CMF(408, 1) = 0.00000859236
        CMF(408, 2) = 0
        CMF(409, 0) = 0.0000221787
        CMF(409, 1) = 0.00000800913
        CMF(409, 2) = 0
        CMF(410, 0) = 0.0000206738
        CMF(410, 1) = 0.0000074657
        CMF(410, 2) = 0
        CMF(411, 0) = 0.0000192723
        CMF(411, 1) = 0.00000695957
        CMF(411, 2) = 0
        CMF(412, 0) = 0.0000179664
        CMF(412, 1) = 0.000006488
        CMF(412, 2) = 0
        CMF(413, 0) = 0.0000167499
        CMF(413, 1) = 0.0000060487
        CMF(413, 2) = 0
        CMF(414, 0) = 0.0000156165
        CMF(414, 1) = 0.0000056394
        CMF(414, 2) = 0
        CMF(415, 0) = 0.0000145598
        CMF(415, 1) = 0.0000052578
        CMF(415, 2) = 0
        CMF(416, 0) = 0.0000135739
        CMF(416, 1) = 0.00000490177
        CMF(416, 2) = 0
        CMF(417, 0) = 0.0000126544
        CMF(417, 1) = 0.00000456972
        CMF(417, 2) = 0
        CMF(418, 0) = 0.0000117972
        CMF(418, 1) = 0.00000426019
        CMF(418, 2) = 0
        CMF(419, 0) = 0.0000109984
        CMF(419, 1) = 0.00000397174
        CMF(419, 2) = 0
        CMF(420, 0) = 0.000010254
        CMF(420, 1) = 0.0000037029
        CMF(420, 2) = 0
        CMF(421, 0) = 0.00000955965
        CMF(421, 1) = 0.00000345216
        CMF(421, 2) = 0
        CMF(422, 0) = 0.00000891204
        CMF(422, 1) = 0.0000032183
        CMF(422, 2) = 0
        CMF(423, 0) = 0.00000830836
        CMF(423, 1) = 0.0000030003
        CMF(423, 2) = 0
        CMF(424, 0) = 0.00000774577
        CMF(424, 1) = 0.00000279714
        CMF(424, 2) = 0
        CMF(425, 0) = 0.00000722146
        CMF(425, 1) = 0.0000026078
        CMF(425, 2) = 0
        CMF(426, 0) = 0.00000673248
        CMF(426, 1) = 0.00000243122
        CMF(426, 2) = 0
        CMF(427, 0) = 0.00000627642
        CMF(427, 1) = 0.00000226653
        CMF(427, 2) = 0
        CMF(428, 0) = 0.0000058513
        CMF(428, 1) = 0.00000211301
        CMF(428, 2) = 0
        CMF(429, 0) = 0.00000545512
        CMF(429, 1) = 0.00000196994
        CMF(429, 2) = 0
        CMF(430, 0) = 0.00000508587
        CMF(430, 1) = 0.0000018366
        CMF(430, 2) = 0
        CMF(431, 0) = 0.00000474147
        CMF(431, 1) = 0.00000171223
        CMF(431, 2) = 0
        CMF(432, 0) = 0.00000442024
        CMF(432, 1) = 0.00000159623
        CMF(432, 2) = 0
        CMF(433, 0) = 0.00000412078
        CMF(433, 1) = 0.00000148809
        CMF(433, 2) = 0
        CMF(434, 0) = 0.00000384172
        CMF(434, 1) = 0.00000138731
        CMF(434, 2) = 0
        CMF(435, 0) = 0.00000358165
        CMF(435, 1) = 0.0000012934
        CMF(435, 2) = 0
        CMF(436, 0) = 0.00000333913
        CMF(436, 1) = 0.00000120582
        CMF(436, 2) = 0
        CMF(437, 0) = 0.00000311295
        CMF(437, 1) = 0.00000112414
        CMF(437, 2) = 0
        CMF(438, 0) = 0.00000290212
        CMF(438, 1) = 0.00000104801
        CMF(438, 2) = 0
        CMF(439, 0) = 0.00000270565
        CMF(439, 1) = 0.000000977058
        CMF(439, 2) = 0
        CMF(440, 0) = 0.00000252253
        CMF(440, 1) = 0.00000091093
        CMF(440, 2) = 0
        CMF(441, 0) = 0.00000235173
        CMF(441, 1) = 0.000000849251
        CMF(441, 2) = 0
        CMF(442, 0) = 0.00000219242
        CMF(442, 1) = 0.000000791721
        CMF(442, 2) = 0
        CMF(443, 0) = 0.0000020439
        CMF(443, 1) = 0.00000073809
        CMF(443, 2) = 0
        CMF(444, 0) = 0.0000019055
        CMF(444, 1) = 0.00000068811
        CMF(444, 2) = 0
        CMF(445, 0) = 0.00000177651
        CMF(445, 1) = 0.00000064153
        CMF(445, 2) = 0
        CMF(446, 0) = 0.00000165622
        CMF(446, 1) = 0.00000059809
        CMF(446, 2) = 0
        CMF(447, 0) = 0.00000154402
        CMF(447, 1) = 0.000000557575
        CMF(447, 2) = 0
        CMF(448, 0) = 0.00000143944
        CMF(448, 1) = 0.000000519808
        CMF(448, 2) = 0
        CMF(449, 0) = 0.00000134198
        CMF(449, 1) = 0.000000484612
        CMF(449, 2) = 0
        CMF(450, 0) = 0.00000125114
        CMF(450, 1) = 0.00000045181
        CMF(450, 2) = 0
    End Sub
#End Region

#Region "CRIcalculation Factors"
    Public tcs1() As Double = {0.219, 0.239, 0.252, 0.256, 0.256, 0.254, 0.252, 0.248, 0.244, 0.24, 0.237, 0.232, 0.23, 0.226, 0.225, 0.222, 0.22, 0.218, 0.216, 0.214, 0.214, 0.214, 0.216, 0.218, 0.223, 0.225, 0.226, 0.226, 0.225, 0.225, 0.227, 0.23, 0.236, 0.245, 0.253, 0.262, 0.272, 0.283, 0.298, 0.318, 0.341, 0.367, 0.39, 0.409, 0.424, 0.435, 0.442, 0.448, 0.45, 0.451, 0.451, 0.451, 0.451, 0.451, 0.45, 0.45, 0.451, 0.451, 0.453, 0.454, 0.455, 0.457, 0.458, 0.46, 0.462, 0.463, 0.464, 0.465, 0.466, 0.466, 0.466, 0.466, 0.467, 0.467, 0.467, 0.467, 0.467, 0.467, 0.467, 0.467, 0.467}
    Public tcs2() As Double = {0.07, 0.079, 0.089, 0.101, 0.111, 0.116, 0.118, 0.12, 0.121, 0.122, 0.122, 0.122, 0.123, 0.124, 0.127, 0.128, 0.131, 0.134, 0.138, 0.143, 0.15, 0.159, 0.174, 0.19, 0.207, 0.225, 0.242, 0.253, 0.26, 0.264, 0.267, 0.269, 0.272, 0.276, 0.282, 0.289, 0.299, 0.309, 0.322, 0.329, 0.335, 0.339, 0.341, 0.341, 0.342, 0.342, 0.342, 0.341, 0.341, 0.339, 0.339, 0.338, 0.338, 0.337, 0.336, 0.335, 0.334, 0.332, 0.332, 0.331, 0.331, 0.33, 0.329, 0.328, 0.328, 0.327, 0.326, 0.325, 0.324, 0.324, 0.324, 0.323, 0.322, 0.321, 0.32, 0.318, 0.316, 0.315, 0.315, 0.314, 0.314}
    Public tcs3() As Double = {0.065, 0.068, 0.07, 0.072, 0.073, 0.073, 0.074, 0.074, 0.074, 0.073, 0.073, 0.073, 0.073, 0.073, 0.074, 0.075, 0.077, 0.08, 0.085, 0.094, 0.109, 0.126, 0.148, 0.172, 0.198, 0.221, 0.241, 0.26, 0.278, 0.302, 0.339, 0.37, 0.392, 0.399, 0.4, 0.393, 0.38, 0.365, 0.349, 0.332, 0.315, 0.299, 0.285, 0.272, 0.264, 0.257, 0.252, 0.247, 0.241, 0.235, 0.229, 0.224, 0.22, 0.217, 0.216, 0.216, 0.219, 0.224, 0.23, 0.238, 0.251, 0.269, 0.288, 0.312, 0.34, 0.366, 0.39, 0.412, 0.431, 0.447, 0.46, 0.472, 0.481, 0.488, 0.493, 0.497, 0.5, 0.502, 0.505, 0.51, 0.516}
    Public tcs4() As Double = {0.074, 0.083, 0.093, 0.105, 0.116, 0.121, 0.124, 0.126, 0.128, 0.131, 0.135, 0.139, 0.144, 0.151, 0.161, 0.172, 0.186, 0.205, 0.229, 0.254, 0.281, 0.308, 0.332, 0.352, 0.37, 0.383, 0.39, 0.394, 0.395, 0.392, 0.385, 0.377, 0.367, 0.354, 0.341, 0.327, 0.312, 0.296, 0.28, 0.263, 0.247, 0.229, 0.214, 0.198, 0.185, 0.175, 0.169, 0.164, 0.16, 0.156, 0.154, 0.152, 0.151, 0.149, 0.148, 0.148, 0.148, 0.149, 0.151, 0.154, 0.158, 0.162, 0.165, 0.168, 0.17, 0.171, 0.17, 0.168, 0.166, 0.164, 0.164, 0.165, 0.168, 0.172, 0.177, 0.181, 0.185, 0.189, 0.192, 0.194, 0.197}
    Public tcs5() As Double = {0.295, 0.306, 0.31, 0.312, 0.313, 0.315, 0.319, 0.322, 0.326, 0.33, 0.334, 0.339, 0.346, 0.352, 0.36, 0.369, 0.381, 0.394, 0.403, 0.41, 0.415, 0.418, 0.419, 0.417, 0.413, 0.409, 0.403, 0.396, 0.389, 0.381, 0.372, 0.363, 0.353, 0.342, 0.331, 0.32, 0.308, 0.296, 0.284, 0.271, 0.26, 0.247, 0.232, 0.22, 0.21, 0.2, 0.194, 0.189, 0.185, 0.183, 0.18, 0.177, 0.176, 0.175, 0.175, 0.175, 0.175, 0.177, 0.18, 0.183, 0.186, 0.189, 0.192, 0.195, 0.199, 0.2, 0.199, 0.198, 0.196, 0.195, 0.195, 0.196, 0.197, 0.2, 0.203, 0.205, 0.208, 0.212, 0.215, 0.217, 0.219}
    Public tcs6() As Double = {0.151, 0.203, 0.265, 0.339, 0.41, 0.464, 0.492, 0.508, 0.517, 0.524, 0.531, 0.538, 0.544, 0.551, 0.556, 0.556, 0.554, 0.549, 0.541, 0.531, 0.519, 0.504, 0.488, 0.469, 0.45, 0.431, 0.414, 0.395, 0.377, 0.358, 0.341, 0.325, 0.309, 0.293, 0.279, 0.265, 0.253, 0.241, 0.234, 0.227, 0.225, 0.222, 0.221, 0.22, 0.22, 0.22, 0.22, 0.22, 0.223, 0.227, 0.233, 0.239, 0.244, 0.251, 0.258, 0.263, 0.268, 0.273, 0.278, 0.281, 0.283, 0.286, 0.291, 0.296, 0.302, 0.313, 0.325, 0.338, 0.351, 0.364, 0.376, 0.389, 0.401, 0.413, 0.425, 0.436, 0.447, 0.458, 0.469, 0.477, 0.485}
    Public tcs7() As Double = {0.378, 0.459, 0.524, 0.546, 0.551, 0.555, 0.559, 0.56, 0.561, 0.558, 0.556, 0.551, 0.544, 0.535, 0.522, 0.506, 0.488, 0.469, 0.448, 0.429, 0.408, 0.385, 0.363, 0.341, 0.324, 0.311, 0.301, 0.291, 0.283, 0.273, 0.265, 0.26, 0.257, 0.257, 0.259, 0.26, 0.26, 0.258, 0.256, 0.254, 0.254, 0.259, 0.27, 0.284, 0.302, 0.324, 0.344, 0.362, 0.377, 0.389, 0.4, 0.41, 0.42, 0.429, 0.438, 0.445, 0.452, 0.457, 0.462, 0.466, 0.468, 0.47, 0.473, 0.477, 0.483, 0.489, 0.496, 0.503, 0.511, 0.518, 0.525, 0.532, 0.539, 0.546, 0.553, 0.559, 0.565, 0.57, 0.575, 0.578, 0.581}
    Public tcs8() As Double = {0.104, 0.129, 0.17, 0.24, 0.319, 0.416, 0.462, 0.482, 0.49, 0.488, 0.482, 0.473, 0.462, 0.45, 0.439, 0.426, 0.413, 0.397, 0.382, 0.366, 0.352, 0.337, 0.325, 0.31, 0.299, 0.289, 0.283, 0.276, 0.27, 0.262, 0.256, 0.251, 0.25, 0.251, 0.254, 0.258, 0.264, 0.269, 0.272, 0.274, 0.278, 0.284, 0.295, 0.316, 0.348, 0.384, 0.434, 0.482, 0.528, 0.568, 0.604, 0.629, 0.648, 0.663, 0.676, 0.685, 0.693, 0.7, 0.705, 0.709, 0.712, 0.715, 0.717, 0.719, 0.721, 0.72, 0.719, 0.722, 0.725, 0.727, 0.729, 0.73, 0.73, 0.73, 0.73, 0.73, 0.73, 0.73, 0.73, 0.73, 0.73}
    Public tcs9() As Double = {0.066, 0.062, 0.058, 0.055, 0.052, 0.052, 0.051, 0.05, 0.05, 0.049, 0.048, 0.047, 0.046, 0.044, 0.042, 0.041, 0.038, 0.035, 0.033, 0.031, 0.03, 0.029, 0.028, 0.028, 0.028, 0.029, 0.03, 0.03, 0.031, 0.031, 0.032, 0.032, 0.033, 0.034, 0.035, 0.037, 0.041, 0.044, 0.048, 0.052, 0.06, 0.076, 0.102, 0.136, 0.19, 0.256, 0.336, 0.418, 0.505, 0.581, 0.641, 0.682, 0.717, 0.74, 0.758, 0.77, 0.781, 0.79, 0.797, 0.803, 0.809, 0.814, 0.819, 0.824, 0.828, 0.83, 0.831, 0.833, 0.835, 0.836, 0.836, 0.837, 0.838, 0.839, 0.839, 0.839, 0.839, 0.839, 0.839, 0.839, 0.839}
    Public tcs10() As Double = {0.05, 0.054, 0.059, 0.063, 0.066, 0.067, 0.068, 0.069, 0.069, 0.07, 0.072, 0.073, 0.076, 0.078, 0.083, 0.088, 0.095, 0.103, 0.113, 0.125, 0.142, 0.162, 0.189, 0.219, 0.262, 0.305, 0.365, 0.416, 0.465, 0.509, 0.546, 0.581, 0.61, 0.634, 0.653, 0.666, 0.678, 0.687, 0.693, 0.698, 0.701, 0.704, 0.705, 0.705, 0.706, 0.707, 0.707, 0.707, 0.708, 0.708, 0.71, 0.711, 0.712, 0.714, 0.716, 0.718, 0.72, 0.722, 0.725, 0.729, 0.731, 0.735, 0.739, 0.742, 0.746, 0.748, 0.749, 0.751, 0.753, 0.754, 0.755, 0.755, 0.755, 0.755, 0.756, 0.757, 0.758, 0.759, 0.759, 0.759, 0.759}
    Public tcs11() As Double = {0.111, 0.121, 0.127, 0.129, 0.127, 0.121, 0.116, 0.112, 0.108, 0.105, 0.104, 0.104, 0.105, 0.106, 0.11, 0.115, 0.123, 0.134, 0.148, 0.167, 0.192, 0.219, 0.252, 0.291, 0.325, 0.347, 0.356, 0.353, 0.346, 0.333, 0.314, 0.294, 0.271, 0.248, 0.227, 0.206, 0.188, 0.17, 0.153, 0.138, 0.125, 0.114, 0.106, 0.1, 0.096, 0.092, 0.09, 0.087, 0.085, 0.082, 0.08, 0.079, 0.078, 0.078, 0.078, 0.078, 0.081, 0.083, 0.088, 0.093, 0.102, 0.112, 0.125, 0.141, 0.161, 0.182, 0.203, 0.223, 0.242, 0.257, 0.27, 0.282, 0.292, 0.302, 0.31, 0.314, 0.317, 0.323, 0.33, 0.334, 0.338}
    Public tcs12() As Double = {0.12, 0.103, 0.09, 0.082, 0.076, 0.068, 0.064, 0.065, 0.075, 0.093, 0.123, 0.16, 0.207, 0.256, 0.3, 0.331, 0.346, 0.347, 0.341, 0.328, 0.307, 0.282, 0.257, 0.23, 0.204, 0.178, 0.154, 0.129, 0.109, 0.09, 0.075, 0.062, 0.051, 0.041, 0.035, 0.029, 0.025, 0.022, 0.019, 0.017, 0.017, 0.017, 0.016, 0.016, 0.016, 0.016, 0.016, 0.016, 0.016, 0.016, 0.018, 0.018, 0.018, 0.018, 0.019, 0.02, 0.023, 0.024, 0.026, 0.03, 0.035, 0.043, 0.056, 0.074, 0.097, 0.128, 0.166, 0.21, 0.257, 0.305, 0.354, 0.401, 0.446, 0.485, 0.52, 0.551, 0.577, 0.599, 0.618, 0.633, 0.645}
    Public tcs13() As Double = {0.104, 0.127, 0.161, 0.211, 0.264, 0.313, 0.341, 0.352, 0.359, 0.361, 0.364, 0.365, 0.367, 0.369, 0.372, 0.374, 0.376, 0.379, 0.384, 0.389, 0.397, 0.405, 0.416, 0.429, 0.443, 0.454, 0.461, 0.466, 0.469, 0.471, 0.474, 0.476, 0.483, 0.49, 0.506, 0.526, 0.553, 0.582, 0.618, 0.651, 0.68, 0.701, 0.717, 0.729, 0.736, 0.742, 0.745, 0.747, 0.748, 0.748, 0.748, 0.748, 0.748, 0.748, 0.748, 0.748, 0.747, 0.747, 0.747, 0.747, 0.747, 0.747, 0.747, 0.746, 0.746, 0.746, 0.745, 0.744, 0.743, 0.744, 0.745, 0.748, 0.75, 0.75, 0.749, 0.748, 0.748, 0.747, 0.747, 0.747, 0.747}
    Public tcs14() As Double = {0.036, 0.036, 0.037, 0.038, 0.039, 0.039, 0.04, 0.041, 0.042, 0.042, 0.043, 0.044, 0.044, 0.045, 0.045, 0.046, 0.047, 0.048, 0.05, 0.052, 0.055, 0.057, 0.062, 0.067, 0.075, 0.083, 0.092, 0.1, 0.108, 0.121, 0.133, 0.142, 0.15, 0.154, 0.155, 0.152, 0.147, 0.14, 0.133, 0.125, 0.118, 0.112, 0.106, 0.101, 0.098, 0.095, 0.093, 0.09, 0.089, 0.087, 0.086, 0.085, 0.084, 0.084, 0.084, 0.084, 0.085, 0.087, 0.092, 0.096, 0.102, 0.11, 0.123, 0.137, 0.152, 0.169, 0.188, 0.207, 0.226, 0.243, 0.26, 0.277, 0.294, 0.31, 0.325, 0.339, 0.353, 0.366, 0.379, 0.39, 0.399}
    Public tcs15() As Double = {0.131, 0.139, 0.147, 0.153, 0.158, 0.162, 0.164, 0.167, 0.17, 0.175, 0.182, 0.192, 0.203, 0.212, 0.221, 0.229, 0.236, 0.243, 0.249, 0.254, 0.259, 0.264, 0.269, 0.276, 0.284, 0.291, 0.296, 0.298, 0.296, 0.289, 0.282, 0.276, 0.274, 0.276, 0.281, 0.286, 0.291, 0.289, 0.286, 0.28, 0.285, 0.314, 0.354, 0.398, 0.44, 0.47, 0.494, 0.511, 0.524, 0.535, 0.544, 0.552, 0.559, 0.565, 0.571, 0.576, 0.581, 0.586, 0.59, 0.594, 0.599, 0.603, 0.606, 0.61, 0.612, 0.614, 0.616, 0.616, 0.616, 0.616, 0.615, 0.613, 0.612, 0.61, 0.609, 0.608, 0.607, 0.607, 0.609, 0.61, 0.611}

    Public cx() As Double = {0.001368, 0.002236, 0.004243, 0.00765, 0.01431, 0.02319, 0.04351, 0.07763, 0.13438, 0.21477, 0.2839, 0.3285, 0.34828, 0.34806, 0.3362, 0.3187, 0.2908, 0.2511, 0.19536, 0.1421, 0.09564, 0.05795001, 0.03201, 0.0147, 0.0049, 0.0024, 0.0093, 0.0291, 0.06327, 0.1096, 0.1655, 0.2257499, 0.2904, 0.3597, 0.4334499, 0.5120501, 0.5945, 0.6784, 0.7621, 0.8425, 0.9163, 0.9786, 1.0263, 1.0567, 1.0622, 1.0456, 1.0026, 0.9384, 0.8544499, 0.7514, 0.6424, 0.5419, 0.4479, 0.3608, 0.2835, 0.2187, 0.1649, 0.1212, 0.0874, 0.0636, 0.04677, 0.0329, 0.0227, 0.01584, 0.01135916, 0.008110916, 0.005790346, 0.004109457, 0.002899327, 0.00204919, 0.001439971, 0.000999949, 0.000690079, 0.000476021, 0.000332301, 0.000234826, 0.000166151, 0.000117413, 0.0000830753, 0.0000587065, 0.0000415099}
    Public cy() As Double = {0.000039, 0.000064, 0.00012, 0.000217, 0.000396, 0.00064, 0.00121, 0.00218, 0.004, 0.0073, 0.0116, 0.01684, 0.023, 0.0298, 0.038, 0.048, 0.06, 0.0739, 0.09098, 0.1126, 0.13902, 0.1693, 0.20802, 0.2586, 0.323, 0.4073, 0.503, 0.6082, 0.71, 0.7932, 0.862, 0.9148501, 0.954, 0.9803, 0.9949501, 1, 0.995, 0.9786, 0.952, 0.9154, 0.87, 0.8163, 0.757, 0.6949, 0.631, 0.5668, 0.503, 0.4412, 0.381, 0.321, 0.265, 0.217, 0.175, 0.1382, 0.107, 0.0816, 0.061, 0.04458, 0.032, 0.0232, 0.017, 0.01192, 0.00821, 0.005723, 0.004102, 0.002929, 0.002091, 0.001484, 0.001047, 0.00074, 0.00052, 0.0003611, 0.0002492, 0.0001719, 0.00012, 0.0000848, 0.00006, 0.0000424, 0.00003, 0.0000212, 0.00001499}
    Public cz() As Double = {0.006450001, 0.01054999, 0.02005001, 0.03621, 0.06785001, 0.1102, 0.2074, 0.3713, 0.6456, 1.0390501, 1.3856, 1.62296, 1.74706, 1.7826, 1.77211, 1.7441, 1.6692, 1.5281, 1.28764, 1.0419, 0.8129501, 0.6162, 0.46518, 0.3533, 0.272, 0.2123, 0.1582, 0.1117, 0.07824999, 0.05725001, 0.04216, 0.02984, 0.0203, 0.0134, 0.008749999, 0.005749999, 0.0039, 0.002749999, 0.0021, 0.0018, 0.001650001, 0.0014, 0.0011, 0.001, 0.0008, 0.0006, 0.00034, 0.00024, 0.00019, 0.0001, 0.00005, 0.00003, 0.00002, 0.00001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

    Public wavelength() As Integer = {380, 385, 390, 395, 400, 405, 410, 415, 420, 425, 430, 435, 440, 445, 450, 455, 460, 465, 470, 475, 480, 485, 490, 495, 500, 505, 510, 515, 520, 525, 530, 535, 540, 545, 550, 555, 560, 565, 570, 575, 580, 585, 590, 595, 600, 605, 610, 615, 620, 625, 630, 635, 640, 645, 650, 655, 660, 665, 670, 675, 680, 685, 690, 695, 700, 705, 710, 715, 720, 725, 730, 735, 740, 745, 750, 755, 760, 765, 770, 775, 780}
    Public dayS0() As Double = {63.4, 64.6, 65.8, 80.3, 94.8, 99.8, 104.8, 105.35, 105.9, 101.35, 96.8, 105.35, 113.9, 119.75, 125.6, 125.55, 125.5, 123.4, 121.3, 121.3, 121.3, 117.4, 113.5, 113.3, 113.1, 111.95, 110.8, 108.65, 106.5, 107.65, 108.8, 107.05, 105.3, 104.85, 104.4, 102.2, 100.0, 98.0, 96.0, 95.55, 95.1, 92.1, 89.1, 89.8, 90.5, 90.4, 90.3, 89.35, 88.4, 86.2, 84.0, 84.55, 85.1, 83.5, 81.9, 82.25, 82.6, 83.7, 84.9, 83.1, 81.3, 76.6, 71.9, 73.1, 74.3, 75.35, 76.4, 69.85, 63.3, 67.5, 71.7, 74.35, 77.0, 71.1, 65.2, 56.45, 47.7, 58.15, 68.6, 66.8, 65.0}
    Public dayS1() As Double = {38.5, 36.75, 35.0, 39.2, 43.4, 44.85, 46.3, 45.1, 43.9, 40.5, 37.1, 36.9, 36.7, 36.3, 35.9, 34.25, 32.6, 30.25, 27.9, 26.1, 24.3, 22.2, 20.1, 18.15, 16.2, 14.7, 13.2, 10.9, 8.6, 7.35, 6.1, 5.15, 4.2, 3.05, 1.9, 0.95, 0.0, -0.8, -1.6, -2.55, -3.5, -3.5, -3.5, -4.65, -5.8, -6.5, -7.2, -7.9, -8.6, -9.05, -9.5, -10.2, -10.9, -10.8, -10.7, -11.35, -12.0, -13.0, -14.0, -13.8, -13.6, -12.8, -12.0, -12.65, -13.3, -13.1, -12.9, -11.75, -10.6, -11.1, -11.6, -11.9, -12.2, -11.2, -10.2, -9.0, -7.8, -9.5, -11.2, -10.8, -10.4}
    Public dayS2() As Double = {3.0, 2.1, 1.2, 0.05, -1.1, -0.8, -0.5, -0.6, -0.7, -0.95, -1.2, -1.9, -2.6, -2.75, -2.9, -2.85, -2.8, -2.7, -2.6, -2.6, -2.6, -2.2, -1.8, -1.65, -1.5, -1.4, -1.3, -1.25, -1.2, -1.1, -1.0, -0.75, -0.5, -0.4, -0.3, -0.15, 0.0, 0.1, 0.2, 0.35, 0.5, 1.3, 2.1, 2.65, 3.2, 3.65, 4.1, 4.4, 4.7, 4.9, 5.1, 5.9, 6.7, 7.0, 7.3, 7.95, 8.6, 9.2, 9.8, 10.0, 10.2, 9.25, 8.3, 8.95, 9.6, 9.05, 8.5, 7.75, 7.0, 7.3, 7.6, 7.8, 8.0, 7.35, 6.7, 5.95, 5.2, 6.3, 7.4, 7.1, 6.8}

    Public planck() As Double = {0.573954871, 0.632830736, 0.695422017, 0.761763166, 0.831876152, 0.905770484, 0.98344332, 1.064879653, 1.150052577, 1.238923621, 1.331443132, 1.427550728, 1.527175786, 1.630237971, 1.736647797, 1.846307223, 1.959110251, 2.074943558, 2.193687122, 2.315214857, 2.439395254, 2.566092001, 2.695164613, 2.826469035, 2.95985824, 3.095182802, 3.232291457, 3.371031635, 3.511249976, 3.652792814, 3.795506644, 3.939238558, 4.083836653, 4.229150421, 4.3750311, 4.521332012, 4.667908864, 4.814620026, 4.961326792, 5.107893601, 5.25418825, 5.400082074, 5.545450105, 5.690171218, 5.834128241, 5.977208064, 6.119301716, 6.260304431, 6.400115693, 6.538639275, 6.675783253, 6.811460012, 6.945586239, 7.078082905, 7.208875234, 7.337892665, 7.465068806, 7.590341374, 7.713652133, 7.834946826, 7.954175097, 8.07129041, 8.186249967, 8.299014611, 8.409548739, 8.517820206, 8.623800222, 8.727463257, 8.828786934, 8.927751932, 9.024341877, 9.118543241, 9.210345235, 9.29973971, 9.386721049, 9.471286065, 9.553433903, 9.633165933, 9.710485658, 9.78539861, 9.857912258}
    Public day() As Double = {2.204433824, 2.320657877, 2.436881929, 3.081228818, 3.725575706, 3.926723329, 4.127870951, 4.179041782, 4.230212613, 4.084783732, 3.939354852, 4.369242308, 4.799129765, 5.088187306, 5.377244848, 5.403749991, 5.430255135, 5.371014391, 5.311773647, 5.344917851, 5.378062055, 5.219886996, 5.061711937, 5.083618072, 5.105524206, 5.075642204, 5.045760203, 4.984737917, 4.923715631, 4.998202263, 5.072688896, 4.99972776, 4.926766624, 4.923605306, 4.920443988, 4.829178419, 4.737912849, 4.654869176, 4.571825502, 4.563473408, 4.555121313, 4.388854535, 4.222587757, 4.260339654, 4.29809155, 4.292670267, 4.287248983, 4.246079702, 4.20491042, 4.102930041, 4.000949661, 4.015768202, 4.030586743, 3.94389027, 3.857193798, 3.866140102, 3.875086406, 3.929888806, 3.984691206, 3.889693738, 3.794696269, 3.585937261, 3.377178253, 3.426396816, 3.47561538, 3.538269733, 3.600924085, 3.292036635, 2.983149185, 3.182299726, 3.381450267, 3.506496644, 3.63154302, 3.353197847, 3.074852673, 2.660810468, 2.246768263, 2.740005101, 3.233241938, 3.14964265, 3.066043363}

    Public Maxlambda As Integer 'As UInteger 
    Public TCS(,) As Double

    Public wave() As Double
    Public lx() As Double
    Public ly() As Double
    Public lz() As Double
    Public ply() As Double
    Public plx() As Double
    Public plz() As Double
    Public dlx() As Double
    Public dly() As Double
    Public dlz() As Double
    Public peaknormal() As Double

    Public de(14) As Double
    Public ri(14) As Double


    Public sumlx As Double
    Public sumly As Double
    Public sumlz As Double

    Public dayM1 As Double
    Public dayM2 As Double

    Public sx As Double = 0.0
    Public sy As Double = 0.0
    Public sz As Double = 0.0

    Public u As Double = 0.0
    Public v As Double = 0.0
    Public w As Double = 0.0
    Public n As Double = 0.0
    Public cct As Double = 0.0
    Public max As Double = 0.0
    Public nom As Double = 0.0
    Public uk As Double = 0.0
    Public vk As Double = 0.0
    Public ck As Double = 0.0
    Public dk As Double = 0.0
    Public up As Double = 0.0
    Public vp As Double = 0.0
    Public cr As Double = 0.0
    Public dr As Double = 0.0
    Public ur As Double = 0.0
    Public vr As Double = 0.0

    Public sum As Double = 0.0
    Public pt As st_Photo
    Public sam As st_Sample
    Public ref As st_reference
    Public tsample As st_light
    Public tref As st_light
    Public reference As st_light_Single
    Public refplanck As st_light_Single
    Public refday As New st_light_Single

    Public Structure st_Photo
        Dim stimulx() As Double
        Dim stimuly() As Double
        Dim stimulz() As Double
    End Structure
    Public Structure st_Sample
        Dim wave() As Integer
        Dim pw() As Double
    End Structure
    Public Structure st_reference
        Dim referencePix() As Double
        Dim wave() As Double
        Dim planck() As Double
        Dim day() As Double
    End Structure
    Public Structure st_light
        Dim XX() As Double
        Dim YY() As Double
        Dim ZZ() As Double
        Dim x() As Double
        Dim y() As Double
        Dim z() As Double
        Dim u() As Double
        Dim v() As Double
        Dim c() As Double
        Dim d() As Double
        Dim up() As Double
        Dim vp() As Double
        Dim W() As Double
        Dim UU() As Double
        Dim VV() As Double
    End Structure
    Public Structure st_light_Single
        Dim XX As Double
        Dim YY As Double
        Dim ZZ As Double
        Dim x As Double
        Dim y As Double
        Dim z As Double
        Dim u As Double
        Dim v As Double
        Dim cct As Double
        Dim c As Double
        Dim d As Double
        Dim up As Double
        Dim vp As Double
        Dim W As Double
        Dim UU As Double
        Dim VV As Double
    End Structure
    Sub useStructure()
        ReDim pt.stimulx(Maxlambda - 1)
        ReDim pt.stimuly(Maxlambda - 1)
        ReDim pt.stimulz(Maxlambda - 1)
        ReDim sam.wave(Maxlambda - 1)
        ReDim sam.pw(Maxlambda - 1)
        ReDim ref.referencePix(Maxlambda - 1)
        ReDim ref.planck(Maxlambda - 1)
        ReDim ref.day(Maxlambda - 1)
        ReDim TCS(14, Maxlambda - 1)
        ReDim wave(Maxlambda - 1)
        ReDim lx(Maxlambda - 1)
        ReDim ly(Maxlambda - 1)
        ReDim lz(Maxlambda - 1)
        ReDim ply(Maxlambda - 1)
        ReDim plx(Maxlambda - 1)
        ReDim plz(Maxlambda - 1)
        ReDim dlx(Maxlambda - 1)
        ReDim dly(Maxlambda - 1)
        ReDim dlz(Maxlambda - 1)
        ReDim peaknormal(Maxlambda - 1)
        ReDim tsample.XX(14)
        ReDim tsample.YY(14)
        ReDim tsample.ZZ(14)
        ReDim tsample.x(14)
        ReDim tsample.y(14)
        ReDim tsample.z(14)
        ReDim tsample.u(14)
        ReDim tsample.v(14)
        ReDim tsample.c(14)
        ReDim tsample.d(14)
        ReDim tsample.up(14)
        ReDim tsample.vp(14)
        ReDim tsample.W(14)
        ReDim tsample.UU(14)
        ReDim tsample.VV(14)
        ReDim tref.VV(14)
        ReDim tref.XX(14)
        ReDim tref.YY(14)
        ReDim tref.ZZ(14)
        ReDim tref.x(14)
        ReDim tref.y(14)
        ReDim tref.z(14)
        ReDim tref.u(14)
        ReDim tref.v(14)
        ReDim tref.W(14)
        ReDim tref.UU(14)
        ReDim tref.VV(14)
    End Sub

#End Region

    Public Function CRICalculation(ByVal wave_length() As Integer, ByVal intensity() As Double, ByRef dCRI As Double) As Boolean

        Dim j As Integer
        Dim i As Integer
        Dim Peaknormal2() As Double
        Dim max2 As Double = 0.0
        Dim norintensity() As Double = Nothing
        Dim nom2 As Double
        Try
            CRIInit(wave_length, intensity)
            norintensity = intensity.Clone
            ColorMatchingFuntions()

            sumlx = 0.0
            sumly = 0.0
            sumlz = 0.0
            reference.XX = 0
            reference.YY = 0
            reference.ZZ = 0

            ReDim de(14)
            ReDim ri(14)
            ReDim peaknormal(Maxlambda - 1)
            ReDim Peaknormal2(intensity.Length - 1)

            For i = 0 To intensity.Length - 1
                If intensity(i) > max2 Then
                    max2 = intensity(i)
                End If
            Next

            nom = 0.0
            nom2 = 0.0
            For i = 0 To Maxlambda - 1
                sam.pw(i) = sam.pw(i) / max
                nom = nom + sam.pw(i) * pt.stimuly(i)
            Next

            For i = 0 To Maxlambda - 1
                peaknormal(i) = (sam.pw(i) / nom) * 100
            Next

            'For i = 0 To intensity.Length - 1
            '    norintensity(i) = norintensity(i) / max2
            '    nom2 = nom2 + norintensity(i) * CMF(i, 1)
            'Next

            'For i = 0 To intensity.Length - 1
            '    Peaknormal2(i) = (norintensity(i) / nom2) * 100
            'Next

            For i = 0 To Maxlambda - 1
                sumlx = sumlx + peaknormal(i) * pt.stimulx(i)
                sumly = sumly + peaknormal(i) * pt.stimuly(i)
                sumlz = sumlz + peaknormal(i) * pt.stimulz(i)
            Next

            '//x,y,z
            sx = sumlx / (sumlx + sumly + sumlz)
            sy = sumly / (sumlx + sumly + sumlz)
            sz = sumlz / (sumlx + sumly + sumlz)

            u = 4 * sx / (-2 * sx + 12 * sy + 3)
            v = 6 * sy / (-2 * sx + 12 * sy + 3)

            n = ((sx - 0.332) / (sy - 0.1858))
            cct = 5520.33 - (6823.3 * n) + (3535 * n * n) - (449 * n * n * n)

            nom = 0

            For i = 0 To Maxlambda - 1
                If cct < 5000 Then

                    ply(i) = 3.7415 * 10 ^ -16 / ((sam.wave(i) * 0.000000001) ^ 5) / (Exp(1.4388 * 10 ^ -2 / (sam.wave(i) * 0.000000001 * cct)) - 1)
                Else
                    If cct < 7000 Then
                        Dim bufm1 As Double = -4.607 * 10 ^ 9 / cct ^ 3 + 2.9678 * 10 ^ 6 / cct ^ 2 + 0.09911 * 10 ^ 3 / cct + 0.244063 ', "0.0000")
                        Dim bufm2XD As Double = bufm1
                        Dim bufm2YD As Double = -3 * bufm1 ^ 2 + 2.87 * bufm1 - 0.275 ', "0.00000")
                        dayM1 = (-1.3515 - 1.7703 * bufm2XD + 5.9114 * bufm2YD) / (0.0241 + 0.2562 * bufm2XD - 0.7341 * bufm2YD) ', "0.00000")
                        dayM2 = (0.03 - 31.4424 * bufm2XD + 30.0717 * bufm2YD) / (0.0241 + 0.2562 * bufm2XD - 0.7341 * bufm2YD) ', "0.00000")

                    Else
                        Dim bufm1 As Double = -2.0064 * 10 ^ 9 / cct ^ 3 + 1.9018 * 10 ^ 6 / cct ^ 2 + 0.24748 * 10 ^ 3 / cct + 0.23704
                        Dim bufm2XD As Double = bufm1
                        Dim bufm2YD As Double = -3 * bufm1 ^ 2 + 2.87 * bufm1 - 0.275
                        dayM1 = (-1.3515 - 1.7703 * bufm2XD + 5.9114 * bufm2YD) / (0.0241 + 0.2562 * bufm2XD - 0.7341 * bufm2YD)
                        dayM2 = (0.03 - 31.4424 * bufm2XD + 30.0717 * bufm2YD) / (0.0241 + 0.2562 * bufm2XD - 0.7341 * bufm2YD)
                    End If

                    ply(i) = dayS0(Array.IndexOf(wavelength, sam.wave(i))) + dayS1(Array.IndexOf(wavelength, sam.wave(i))) * dayM1 + dayS2(Array.IndexOf(wavelength, sam.wave(i))) * dayM2
                End If
            Next

            For i = 0 To Maxlambda - 1
                nom = nom + ply(i) * pt.stimuly(i)
            Next

            For i = 0 To Maxlambda - 1
                ref.referencePix(i) = ply(i) / nom * 100
                reference.XX = reference.XX + ref.referencePix(i) * pt.stimulx(i)
                reference.YY = reference.YY + ref.referencePix(i) * pt.stimuly(i)
                reference.ZZ = reference.ZZ + ref.referencePix(i) * pt.stimulz(i)
            Next

            For i = 0 To 14
                tref.XX(i) = 0.0
                tref.YY(i) = 0.0
                tref.ZZ(i) = 0.0
                tsample.XX(i) = 0.0
                tsample.YY(i) = 0.0
                tsample.ZZ(i) = 0.0
            Next

            For j = 0 To 14
                For i = 0 To Maxlambda - 1
                    tref.XX(j) = tref.XX(j) + ref.referencePix(i) * pt.stimulx(i) * TCS(j, i)
                    tref.YY(j) = tref.YY(j) + ref.referencePix(i) * pt.stimuly(i) * TCS(j, i)
                    tref.ZZ(j) = tref.ZZ(j) + ref.referencePix(i) * pt.stimulz(i) * TCS(j, i)
                    tsample.XX(j) = tsample.XX(j) + peaknormal(i) * pt.stimulx(i) * TCS(j, i)
                    tsample.YY(j) = tsample.YY(j) + peaknormal(i) * pt.stimuly(i) * TCS(j, i)
                    tsample.ZZ(j) = tsample.ZZ(j) + peaknormal(i) * pt.stimulz(i) * TCS(j, i)
                Next
            Next

            For i = 0 To 14
                tsample.x(i) = tsample.XX(i) / (tsample.XX(i) + tsample.YY(i) + tsample.ZZ(i))
                tsample.y(i) = tsample.YY(i) / (tsample.XX(i) + tsample.YY(i) + tsample.ZZ(i))
                tsample.z(i) = tsample.ZZ(i) / (tsample.XX(i) + tsample.YY(i) + tsample.ZZ(i))
                tref.x(i) = tref.XX(i) / (tref.XX(i) + tref.YY(i) + tref.ZZ(i))
                tref.y(i) = tref.YY(i) / (tref.XX(i) + tref.YY(i) + tref.ZZ(i))
                tref.z(i) = tref.ZZ(i) / (tref.XX(i) + tref.YY(i) + tref.ZZ(i))
            Next

            ' u,v
            For i = 0 To 14
                tsample.u(i) = 4 * tsample.x(i) / (-2 * tsample.x(i) + 12 * tsample.y(i) + 3)
                tsample.v(i) = 6 * tsample.y(i) / (-2 * tsample.x(i) + 12 * tsample.y(i) + 3)
                tref.u(i) = 4 * tref.x(i) / (-2 * tref.x(i) + 12 * tref.y(i) + 3)
                tref.v(i) = 6 * tref.y(i) / (-2 * tref.x(i) + 12 * tref.y(i) + 3)
            Next

            For i = 0 To 14
                tsample.c(i) = (4 - tsample.u(i) - 10 * tsample.v(i)) / tsample.v(i)
                tsample.d(i) = (1.708 * tsample.v(i) + 0.404 - 1.481 * tsample.u(i)) / tsample.v(i)
            Next

            ur = 4 * reference.XX / (reference.XX + 15 * reference.YY + 3 * reference.ZZ)
            vr = 6 * reference.YY / (reference.XX + 15 * reference.YY + 3 * reference.ZZ)

            ck = (4 - u - 10 * v) / v
            dk = (1.708 * v + 0.404 - 1.481 * u) / v
            cr = (4 - ur - 10 * vr) / vr
            dr = (1.708 * vr + 0.404 - 1.481 * ur) / vr

            uk = Format((10.872 + 0.404 * cr / ck * ck - 4 * dr / dk * dk) / (16.518 + 1.481 * cr / ck * ck - dr / dk * dk), "0.0000")
            vk = Format(5.52 / (16.518 + 1.481 * cr / ck * ck - dr / dk * dk), "0.0000")

            '// uprime, vprime
            For i = 0 To 14
                tsample.up(i) = (10.872 + 0.404 * (cr / ck) * tsample.c(i) - 4 * (dr / dk) * tsample.d(i)) / (16.518 + 1.481 * (cr / ck) * tsample.c(i) - (dr / dk) * tsample.d(i))
                tsample.vp(i) = 5.52 / (16.518 + 1.481 * (cr / ck) * tsample.c(i) - (dr / dk) * tsample.d(i))
            Next

            For i = 0 To 14
                tsample.W(i) = 25 * Pow(tsample.YY(i), 1.0 / 3.0) - 17
                tref.W(i) = 25 * Pow(tref.YY(i), 1.0 / 3.0) - 17
            Next

            For i = 0 To 14
                tsample.UU(i) = 13 * tsample.W(i) * (tsample.up(i) - uk)
                tsample.VV(i) = 13 * tsample.W(i) * (tsample.vp(i) - vk)
                tref.UU(i) = 13 * tref.W(i) * (tref.u(i) - ur)
                tref.VV(i) = 13 * tref.W(i) * (tref.v(i) - vr)
            Next

            For i = 0 To 14
                de(i) = Pow((tref.UU(i) - tsample.UU(i)) * (tref.UU(i) - tsample.UU(i)) + (tref.VV(i) - tsample.VV(i)) * (tref.VV(i) - tsample.VV(i)) + (tref.W(i) - tsample.W(i)) * (tref.W(i) - tsample.W(i)), 1.0 / 2.0)
            Next

            sum = 0.0

            For i = 0 To 7
                ri(i) = 100 - 4.6 * de(i)
                ri(i) = 10 * Math.Log(Exp(ri(i) / 10) + 1)
                sum = sum + ri(i)
            Next
            For i = 8 To 14
                ri(i) = 100 - 4.6 * de(i)
                ri(i) = 10 * Math.Log(Exp(ri(i) / 10) + 1)
            Next

            dCRI = sum / 8
            '    dPeakNorm = Peaknormal2.Clone

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Sub CRIInit(ByVal wave_length() As Integer, ByVal intensity() As Double)

        Dim BuffWavelength() As Integer = Nothing
        Dim BuffIntensity() As Double = Nothing

        ConvertTolamda(wave_length, intensity, BuffWavelength, BuffIntensity)

        Maxlambda = BuffIntensity.Length

        useStructure()

        For i As Integer = 0 To Maxlambda - 1
            TCS(0, i) = tcs1(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(1, i) = tcs2(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(2, i) = tcs3(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(3, i) = tcs4(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(4, i) = tcs5(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(5, i) = tcs6(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(6, i) = tcs7(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(7, i) = tcs8(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(8, i) = tcs9(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(9, i) = tcs10(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(10, i) = tcs11(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(11, i) = tcs12(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(12, i) = tcs13(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(13, i) = tcs14(Array.IndexOf(wavelength, BuffWavelength(i)))
            TCS(14, i) = tcs15(Array.IndexOf(wavelength, BuffWavelength(i)))
        Next

        '//CMF입력
        For i As Integer = 0 To Maxlambda - 1
            pt.stimulx(i) = cx(Array.IndexOf(wavelength, BuffWavelength(i)))
            pt.stimuly(i) = cy(Array.IndexOf(wavelength, BuffWavelength(i)))
            pt.stimulz(i) = cz(Array.IndexOf(wavelength, BuffWavelength(i)))
        Next

        Dim num As Integer
        num = 0
        max = 0.0
        sam.wave = BuffWavelength.Clone
        sam.pw = BuffIntensity.Clone
        For i As Integer = 0 To BuffIntensity.Length - 1
            If BuffIntensity(i) > max Then
                max = BuffIntensity(i)
            End If
        Next
    End Sub

    Function ConvertTolamda(ByVal m_pLambda() As Integer, ByVal l_pSpectrum() As Double, ByRef m_Lamda() As Integer, ByRef l_Spectrum() As Double) As Boolean
        ' Dim ReturnStep As Integer
        Dim num As Integer = 0
        Try
            For i As Integer = 0 To m_pLambda.Length - 1
                If m_pLambda(i) Mod 5 = 0 Then
                    ReDim Preserve m_Lamda(num)
                    ReDim Preserve l_Spectrum(num)
                    m_Lamda(num) = m_pLambda(i)
                    l_Spectrum(num) = l_pSpectrum(i)
                    num += 1
                End If
            Next
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function Cal_FWHM(ByVal nELmax As Integer, ByVal dNomrIntensity() As Double, ByVal nWavelength() As Integer, ByRef dFWHM As Double) As Boolean
        Dim sELData As sSpectrumData
        Dim dL_EL_Wavelength, dR_EL_Wavelength As Double
        Dim dBuf_Intensity As Double
        Dim nLSerchNumber As Integer
        Dim nRSerchNumber As Integer
        Dim dStandardValue As Double = 0.5
        Dim dWave() As Double = Nothing
        Dim dIntensity() As Double = Nothing

        nLSerchNumber = nELmax - 380
        nRSerchNumber = 780 - nELmax

        'Serch Left Min(top), Max(botton)
        For i As Integer = 0 To nLSerchNumber
            dBuf_Intensity = dStandardValue - dNomrIntensity(i)

            'dStandard 값이 -면 top, +면 botton
            If dBuf_Intensity <= 0 Then
                'top
                If dBuf_Intensity > sELData.dLeft_Top_Intensity Or sELData.dLeft_Top_Intensity = 0 Then
                    sELData.dLeft_Top_Intensity = dBuf_Intensity
                    sELData.dLeft_Top_Wavelength = nWavelength(i)
                End If
            Else
                'botton
                If dBuf_Intensity <= sELData.dLeft_Botton_Intensity Or sELData.dLeft_Botton_Intensity = 0 Then
                    sELData.dLeft_Botton_Intensity = dBuf_Intensity
                    sELData.dLeft_Botton_Wavelength = nWavelength(i)
                End If
            End If
        Next

        'Serch Right Min(top), Max(botton)
        For i As Integer = nLSerchNumber To nRSerchNumber + nLSerchNumber
            dBuf_Intensity = dStandardValue - dNomrIntensity(i)

            'dStandard 값이 -면 top, +면 botton
            If dBuf_Intensity <= 0 Then
                'top
                If dBuf_Intensity > sELData.dRight_Top_Intensity Or sELData.dRight_Top_Intensity = 0 Then
                    sELData.dRight_Top_Intensity = dBuf_Intensity
                    sELData.dRight_Top_Wavelength = nWavelength(i)
                End If
            Else
                'botton
                If dBuf_Intensity <= sELData.dRight_Botton_Intensity Or sELData.dRight_Botton_Intensity = 0 Then
                    sELData.dRight_Botton_Intensity = dBuf_Intensity
                    sELData.dRight_Botton_Wavelength = nWavelength(i)
                End If
            End If
        Next

        'Interpolation

        ReDim dWave(1)
        ReDim dIntensity(1)

        dWave(0) = sELData.dLeft_Botton_Wavelength
        dWave(1) = sELData.dLeft_Top_Wavelength
        dIntensity(0) = sELData.dLeft_Botton_Intensity
        dIntensity(1) = sELData.dLeft_Top_Intensity

        Interpolation(dWave, dIntensity, dL_EL_Wavelength, 0)

        ReDim dWave(1)
        ReDim dIntensity(1)

        dWave(0) = sELData.dRight_Botton_Wavelength
        dWave(1) = sELData.dRight_Top_Wavelength
        dIntensity(0) = sELData.dRight_Botton_Intensity
        dIntensity(1) = sELData.dRight_Top_Intensity

        Interpolation(dWave, dIntensity, dR_EL_Wavelength, 0)


        'sELData()
        'dL_EL_Intensity_Top, dL_EL_Intensity_Botton, dR_EL_Intensity_Top, dR_EL_Intensity_Botton
        'dL_EL_Wavelength_Top, dL_EL_Wavelength_Botton, dR_EL_Wavelength_Top, dR_EL_Wavelength_Botton

        'return dL_EL_Wavelength, dR_EL_Wavelength
        dFWHM = Math.Abs(dR_EL_Wavelength - dL_EL_Wavelength)

        Return True
    End Function

    Public Function Interpolation(ByVal x() As Double, ByVal y() As Double, ByRef ref_x As Double, ByVal ref_y As Double) As Boolean

        'ref_y = ((y(1) - y(0)) / (x(1) - x(0))) * (ref_x - x(0)) + y(0)
        '  ref_x = ((x(1) - x(0)) / (ref_y - y(0))) * (y(1) - ref_y) + x(0)
        ref_x = (x(1) - x(0)) * (ref_y - y(0)) / (y(1) - y(0)) + x(0)
        Return True
    End Function

    Public Structure sSpectrumData
        Dim dLeft_Top_Wavelength As Double
        Dim dLeft_Top_Intensity As Double
        Dim dLeft_Botton_Wavelength As Double
        Dim dLeft_Botton_Intensity As Double
        Dim dRight_Top_Wavelength As Double
        Dim dRight_Top_Intensity As Double
        Dim dRight_Botton_Wavelength As Double
        Dim dRight_Botton_Intensity As Double
    End Structure

    'Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
    '    Dim nELmax As Integer
    '    Dim dNormaData() As Double
    '    Dim nWavelength() As Integer
    '    Dim dFWHM As Double

    '    'temp = Intensity Data
    '    ReDim nWavelength(temp.Length - 1)

    '    For i As Integer = 0 To nWavelength.Length - 1
    '        nWavelength(i) = 380 + i
    '    Next

    '    'Cal Normalization
    '    dNormaData = DataNormalization(temp, nELmax)

    '    'Cal FWHM
    '    Cal_FWHM(nELmax, dNormaData, nWavelength, dFWHM)

    'End Sub

    Public Function DataNormalization(ByVal inData() As Double, ByRef nELmax As Integer) As Double()

        Dim nNumOfDataPoint As Integer
        Dim nCntDPoint As Integer
        Dim dMaxValue As Double = 0
        Dim nIndexOfMaxVal As Integer
        Dim dDataBuf As Double
        Dim dNormalizedData() As Double

        nNumOfDataPoint = inData.Length
        ReDim dNormalizedData(nNumOfDataPoint - 1)

        '1. Max값 찾기
        dMaxValue = GetMaxValue(inData, nIndexOfMaxVal)

        '2. Max값을 기준으로 Normalization 시작
        For nCntDPoint = 0 To nNumOfDataPoint - 1
            dDataBuf = inData(nCntDPoint) / dMaxValue

            dNormalizedData(nCntDPoint) = dDataBuf
        Next

        nELmax = nIndexOfMaxVal + 380
        Return dNormalizedData

    End Function

    Public Function GetMaxValue(ByVal inData() As Double, ByRef out_index As Integer) As Double

        Dim nNumOfDataPoint As Integer
        Dim nCntDPoint As Integer
        Dim dMaxValue As Double = 0
        Dim dIndexOfMaxVal As Integer

        nNumOfDataPoint = inData.Length
        '1. Max값 찾기
        For nCntDPoint = 0 To nNumOfDataPoint - 1
            If dMaxValue < inData(nCntDPoint) Then
                dMaxValue = inData(nCntDPoint)
                dIndexOfMaxVal = nCntDPoint
            End If
        Next
        out_index = dIndexOfMaxVal
        Return dMaxValue
    End Function
End Module