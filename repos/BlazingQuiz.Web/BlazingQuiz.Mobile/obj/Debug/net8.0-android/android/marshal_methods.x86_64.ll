; ModuleID = 'marshal_methods.x86_64.ll'
source_filename = "marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [342 x ptr] zeroinitializer, align 16

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [684 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 247
	i64 98382396393917666, ; 1: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 203
	i64 120698629574877762, ; 2: Mono.Android => 0x1accec39cafe242 => 171
	i64 131669012237370309, ; 3: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 213
	i64 196720943101637631, ; 4: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 58
	i64 210515253464952879, ; 5: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 234
	i64 229794953483747371, ; 6: System.ValueTuple.dll => 0x330654aed93802b => 151
	i64 232391251801502327, ; 7: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 275
	i64 295915112840604065, ; 8: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 278
	i64 316157742385208084, ; 9: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 241
	i64 350667413455104241, ; 10: System.ServiceProcess.dll => 0x4ddd227954be8f1 => 132
	i64 354178770117062970, ; 11: Microsoft.Extensions.Options.ConfigurationExtensions.dll => 0x4ea4bb703cff13a => 202
	i64 396868157601372792, ; 12: Microsoft.VisualStudio.DesignTools.TapContract => 0x581f57c947e5a78 => 340
	i64 422779754995088667, ; 13: System.IO.UnmanagedMemoryStream => 0x5de03f27ab57d1b => 56
	i64 435118502366263740, ; 14: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x609d9f8f8bdb9bc => 277
	i64 545109961164950392, ; 15: fi/Microsoft.Maui.Controls.resources.dll => 0x7909e9f1ec38b78 => 309
	i64 560278790331054453, ; 16: System.Reflection.Primitives => 0x7c6829760de3975 => 95
	i64 634308326490598313, ; 17: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 260
	i64 648449422406355874, ; 18: Microsoft.Extensions.Configuration.FileExtensions.dll => 0x8ffc15065568ba2 => 186
	i64 649145001856603771, ; 19: System.Security.SecureString => 0x90239f09b62167b => 129
	i64 668723562677762733, ; 20: Microsoft.Extensions.Configuration.Binder.dll => 0x947c88986577aad => 185
	i64 683390398661839228, ; 21: Microsoft.Extensions.FileProviders.Embedded => 0x97be3f26326c97c => 194
	i64 750875890346172408, ; 22: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 145
	i64 798450721097591769, ; 23: Xamarin.AndroidX.Collection.Ktx.dll => 0xb14aab351ad2bd9 => 235
	i64 799765834175365804, ; 24: System.ComponentModel.dll => 0xb1956c9f18442ac => 18
	i64 849051935479314978, ; 25: hi/Microsoft.Maui.Controls.resources.dll => 0xbc8703ca21a3a22 => 312
	i64 872800313462103108, ; 26: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 246
	i64 895210737996778430, ; 27: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0xc6c6d6c5569cbbe => 261
	i64 940822596282819491, ; 28: System.Transactions => 0xd0e792aa81923a3 => 150
	i64 960778385402502048, ; 29: System.Runtime.Handles.dll => 0xd555ed9e1ca1ba0 => 104
	i64 1010599046655515943, ; 30: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 95
	i64 1120440138749646132, ; 31: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 290
	i64 1121665720830085036, ; 32: nb/Microsoft.Maui.Controls.resources.dll => 0xf90f507becf47ac => 320
	i64 1268860745194512059, ; 33: System.Drawing.dll => 0x119be62002c19ebb => 36
	i64 1301626418029409250, ; 34: System.Diagnostics.FileVersionInfo => 0x12104e54b4e833e2 => 28
	i64 1315114680217950157, ; 35: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 230
	i64 1369545283391376210, ; 36: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 268
	i64 1404195534211153682, ; 37: System.IO.FileSystem.Watcher.dll => 0x137cb4660bd87f12 => 50
	i64 1425944114962822056, ; 38: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 115
	i64 1476839205573959279, ; 39: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 70
	i64 1486715745332614827, ; 40: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 210
	i64 1492954217099365037, ; 41: System.Net.HttpListener => 0x14b809f350210aad => 65
	i64 1513467482682125403, ; 42: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 170
	i64 1537168428375924959, ; 43: System.Threading.Thread.dll => 0x15551e8a954ae0df => 145
	i64 1556147632182429976, ; 44: ko/Microsoft.Maui.Controls.resources.dll => 0x15988c06d24c8918 => 318
	i64 1576750169145655260, ; 45: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x15e1bdecc376bfdc => 289
	i64 1624659445732251991, ; 46: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 229
	i64 1628611045998245443, ; 47: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 264
	i64 1636321030536304333, ; 48: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 254
	i64 1651782184287836205, ; 49: System.Globalization.Calendars => 0x16ec4f2524cb982d => 40
	i64 1659332977923810219, ; 50: System.Reflection.DispatchProxy => 0x1707228d493d63ab => 89
	i64 1682513316613008342, ; 51: System.Net.dll => 0x17597cf276952bd6 => 81
	i64 1735388228521408345, ; 52: System.Net.Mail.dll => 0x181556663c69b759 => 66
	i64 1743969030606105336, ; 53: System.Memory.dll => 0x1833d297e88f2af8 => 62
	i64 1767386781656293639, ; 54: System.Private.Uri.dll => 0x188704e9f5582107 => 86
	i64 1776954265264967804, ; 55: Microsoft.JSInterop.dll => 0x18a9027d533bd07c => 208
	i64 1795316252682057001, ; 56: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 228
	i64 1825687700144851180, ; 57: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 106
	i64 1835311033149317475, ; 58: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 308
	i64 1836611346387731153, ; 59: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 275
	i64 1854145951182283680, ; 60: System.Runtime.CompilerServices.VisualC => 0x19bb3feb3df2e3a0 => 102
	i64 1875417405349196092, ; 61: System.Drawing.Primitives => 0x1a06d2319b6c713c => 35
	i64 1875917498431009007, ; 62: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 225
	i64 1881198190668717030, ; 63: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 330
	i64 1897575647115118287, ; 64: Xamarin.AndroidX.Security.SecurityCrypto => 0x1a558aff4cba86cf => 277
	i64 1920760634179481754, ; 65: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 211
	i64 1959996714666907089, ; 66: tr/Microsoft.Maui.Controls.resources.dll => 0x1b334ea0a2a755d1 => 330
	i64 1972385128188460614, ; 67: System.Security.Cryptography.Algorithms => 0x1b5f51d2edefbe46 => 119
	i64 1981742497975770890, ; 68: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 262
	i64 1983698669889758782, ; 69: cs/Microsoft.Maui.Controls.resources.dll => 0x1b87836e2031a63e => 304
	i64 2019660174692588140, ; 70: pl/Microsoft.Maui.Controls.resources.dll => 0x1c07463a6f8e1a6c => 322
	i64 2040001226662520565, ; 71: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 142
	i64 2062890601515140263, ; 72: System.Threading.Tasks.Dataflow => 0x1ca0dc1289cd44a7 => 141
	i64 2064708342624596306, ; 73: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x1ca7514c5eecb152 => 298
	i64 2080945842184875448, ; 74: System.IO.MemoryMappedFiles => 0x1ce10137d8416db8 => 53
	i64 2102659300918482391, ; 75: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 35
	i64 2106033277907880740, ; 76: System.Threading.Tasks.Dataflow.dll => 0x1d3a221ba6d9cb24 => 141
	i64 2165310824878145998, ; 77: Xamarin.Android.Glide.GifDecoder => 0x1e0cbab9112b81ce => 222
	i64 2165725771938924357, ; 78: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 232
	i64 2174121502719587608, ; 79: BlazingQuiz.Shared.Components => 0x1e2c07fcdc23b518 => 336
	i64 2200176636225660136, ; 80: Microsoft.Extensions.Logging.Debug.dll => 0x1e8898fe5d5824e8 => 200
	i64 2262844636196693701, ; 81: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 246
	i64 2287834202362508563, ; 82: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 8
	i64 2287887973817120656, ; 83: System.ComponentModel.DataAnnotations.dll => 0x1fc035fd8d41f790 => 14
	i64 2295368378960711535, ; 84: Microsoft.AspNetCore.Components.WebView.Maui.dll => 0x1fdac961189e0f6f => 181
	i64 2302323944321350744, ; 85: ru/Microsoft.Maui.Controls.resources.dll => 0x1ff37f6ddb267c58 => 326
	i64 2304837677853103545, ; 86: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0x1ffc6da80d5ed5b9 => 274
	i64 2315304989185124968, ; 87: System.IO.FileSystem.dll => 0x20219d9ee311aa68 => 51
	i64 2329709569556905518, ; 88: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 257
	i64 2335503487726329082, ; 89: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 136
	i64 2337758774805907496, ; 90: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 101
	i64 2470498323731680442, ; 91: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 239
	i64 2479423007379663237, ; 92: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 284
	i64 2497223385847772520, ; 93: System.Runtime => 0x22a7eb7046413568 => 116
	i64 2547086958574651984, ; 94: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 223
	i64 2566579877633172060, ; 95: Refit => 0x239e52cce5fda25c => 215
	i64 2592350477072141967, ; 96: System.Xml.dll => 0x23f9e10627330e8f => 163
	i64 2602673633151553063, ; 97: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 329
	i64 2612152650457191105, ; 98: Microsoft.IdentityModel.Tokens.dll => 0x24403afeed9892c1 => 207
	i64 2624866290265602282, ; 99: mscorlib.dll => 0x246d65fbde2db8ea => 166
	i64 2632269733008246987, ; 100: System.Net.NameResolution => 0x2487b36034f808cb => 67
	i64 2656907746661064104, ; 101: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 188
	i64 2662981627730767622, ; 102: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 304
	i64 2706075432581334785, ; 103: System.Net.WebSockets => 0x258de944be6c0701 => 80
	i64 2781169761569919449, ; 104: Microsoft.JSInterop => 0x2698b329b26ed1d9 => 208
	i64 2783046991838674048, ; 105: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 101
	i64 2787234703088983483, ; 106: Xamarin.AndroidX.Startup.StartupRuntime => 0x26ae3f31ef429dbb => 279
	i64 2789714023057451704, ; 107: Microsoft.IdentityModel.JsonWebTokens.dll => 0x26b70e1f9943eab8 => 205
	i64 2815524396660695947, ; 108: System.Security.AccessControl => 0x2712c0857f68238b => 117
	i64 2895129759130297543, ; 109: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 309
	i64 2923871038697555247, ; 110: Jsr305Binding => 0x2893ad37e69ec52f => 291
	i64 3017136373564924869, ; 111: System.Net.WebProxy => 0x29df058bd93f63c5 => 78
	i64 3017704767998173186, ; 112: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 290
	i64 3062772059105072826, ; 113: Microsoft.VisualStudio.DesignTools.MobileTapContracts => 0x2a8126f5e2f316ba => 339
	i64 3106852385031680087, ; 114: System.Runtime.Serialization.Xml => 0x2b1dc1c88b637057 => 114
	i64 3110390492489056344, ; 115: System.Security.Cryptography.Csp.dll => 0x2b2a53ac61900058 => 121
	i64 3135773902340015556, ; 116: System.IO.FileSystem.DriveInfo.dll => 0x2b8481c008eac5c4 => 48
	i64 3266690593535380875, ; 117: Microsoft.AspNetCore.Authorization => 0x2d559dc982c94d8b => 174
	i64 3281594302220646930, ; 118: System.Security.Principal => 0x2d8a90a198ceba12 => 128
	i64 3289520064315143713, ; 119: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 255
	i64 3303437397778967116, ; 120: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 226
	i64 3311221304742556517, ; 121: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 82
	i64 3325875462027654285, ; 122: System.Runtime.Numerics => 0x2e27e21c8958b48d => 110
	i64 3328853167529574890, ; 123: System.Net.Sockets.dll => 0x2e327651a008c1ea => 75
	i64 3344514922410554693, ; 124: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 301
	i64 3396143930648122816, ; 125: Microsoft.Extensions.FileProviders.Abstractions => 0x2f2186e9506155c0 => 192
	i64 3402534845034375023, ; 126: System.IdentityModel.Tokens.Jwt.dll => 0x2f383b6a0629a76f => 217
	i64 3429672777697402584, ; 127: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 213
	i64 3437845325506641314, ; 128: System.IO.MemoryMappedFiles.dll => 0x2fb5ae1beb8f7da2 => 53
	i64 3493805808809882663, ; 129: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 281
	i64 3494946837667399002, ; 130: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 183
	i64 3508450208084372758, ; 131: System.Net.Ping => 0x30b084e02d03ad16 => 69
	i64 3522470458906976663, ; 132: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 280
	i64 3531994851595924923, ; 133: System.Numerics => 0x31042a9aade235bb => 83
	i64 3551103847008531295, ; 134: System.Private.CoreLib.dll => 0x31480e226177735f => 172
	i64 3567343442040498961, ; 135: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 324
	i64 3571415421602489686, ; 136: System.Runtime.dll => 0x319037675df7e556 => 116
	i64 3638003163729360188, ; 137: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 184
	i64 3647754201059316852, ; 138: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 156
	i64 3655542548057982301, ; 139: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 183
	i64 3659371656528649588, ; 140: Xamarin.Android.Glide.Annotations => 0x32c8b3222885dd74 => 220
	i64 3716579019761409177, ; 141: netstandard.dll => 0x3393f0ed5c8c5c99 => 167
	i64 3727469159507183293, ; 142: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 273
	i64 3753897248517198740, ; 143: Microsoft.AspNetCore.Components.WebView.dll => 0x341885a8952f1394 => 180
	i64 3772598417116884899, ; 144: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 247
	i64 3794322307918838949, ; 145: Microsoft.AspNetCore.Metadata.dll => 0x34a824092ed7bca5 => 182
	i64 3869221888984012293, ; 146: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 198
	i64 3869649043256705283, ; 147: System.Diagnostics.Tools => 0x35b3c14d74bf0103 => 32
	i64 3889433610606858880, ; 148: Microsoft.Extensions.FileProviders.Physical.dll => 0x35fa0b4301afd280 => 195
	i64 3890352374528606784, ; 149: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 211
	i64 3919223565570527920, ; 150: System.Security.Cryptography.Encoding => 0x3663e111652bd2b0 => 122
	i64 3933965368022646939, ; 151: System.Net.Requests => 0x369840a8bfadc09b => 72
	i64 3966267475168208030, ; 152: System.Memory => 0x370b03412596249e => 62
	i64 4006972109285359177, ; 153: System.Xml.XmlDocument => 0x379b9fe74ed9fe49 => 161
	i64 4009997192427317104, ; 154: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 113
	i64 4073500526318903918, ; 155: System.Private.Xml.dll => 0x3887fb25779ae26e => 88
	i64 4073631083018132676, ; 156: Microsoft.Maui.Controls.Compatibility.dll => 0x388871e311491cc4 => 209
	i64 4120493066591692148, ; 157: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 335
	i64 4148881117810174540, ; 158: System.Runtime.InteropServices.JavaScript.dll => 0x3993c9651a66aa4c => 105
	i64 4154383907710350974, ; 159: System.ComponentModel => 0x39a7562737acb67e => 18
	i64 4167269041631776580, ; 160: System.Threading.ThreadPool => 0x39d51d1d3df1cf44 => 146
	i64 4168469861834746866, ; 161: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 118
	i64 4187479170553454871, ; 162: System.Linq.Expressions => 0x3a1cea1e912fa117 => 58
	i64 4201423742386704971, ; 163: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 241
	i64 4205801962323029395, ; 164: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 17
	i64 4235503420553921860, ; 165: System.IO.IsolatedStorage.dll => 0x3ac787eb9b118544 => 52
	i64 4282138915307457788, ; 166: System.Reflection.Emit => 0x3b6d36a7ddc70cfc => 92
	i64 4321177614414309855, ; 167: Microsoft.VisualStudio.DesignTools.MobileTapContracts.dll => 0x3bf7e8254e88e9df => 339
	i64 4356591372459378815, ; 168: vi/Microsoft.Maui.Controls.resources.dll => 0x3c75b8c562f9087f => 332
	i64 4373617458794931033, ; 169: System.IO.Pipes.dll => 0x3cb235e806eb2359 => 55
	i64 4384840217421645357, ; 170: Microsoft.AspNetCore.Components.Forms => 0x3cda14f22443862d => 177
	i64 4388777479429739993, ; 171: Microsoft.Maui.Controls.HotReload.Forms.dll => 0x3ce811dd63a4d5d9 => 338
	i64 4397634830160618470, ; 172: System.Security.SecureString.dll => 0x3d0789940f9be3e6 => 129
	i64 4477672992252076438, ; 173: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 152
	i64 4484706122338676047, ; 174: System.Globalization.Extensions.dll => 0x3e3ce07510042d4f => 41
	i64 4533124835995628778, ; 175: System.Reflection.Emit.dll => 0x3ee8e505540534ea => 92
	i64 4636684751163556186, ; 176: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 285
	i64 4657212095206026001, ; 177: Microsoft.Extensions.Http.dll => 0x40a1bdb9c2686b11 => 197
	i64 4672453897036726049, ; 178: System.IO.FileSystem.Watcher => 0x40d7e4104a437f21 => 50
	i64 4679594760078841447, ; 179: ar/Microsoft.Maui.Controls.resources.dll => 0x40f142a407475667 => 302
	i64 4716677666592453464, ; 180: System.Xml.XmlSerializer => 0x417501590542f358 => 162
	i64 4743821336939966868, ; 181: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 13
	i64 4759461199762736555, ; 182: Xamarin.AndroidX.Lifecycle.Process.dll => 0x420d00be961cc5ab => 259
	i64 4794310189461587505, ; 183: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 223
	i64 4795410492532947900, ; 184: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 280
	i64 4809057822547766521, ; 185: System.Drawing => 0x42bd349c3145ecf9 => 36
	i64 4814660307502931973, ; 186: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 67
	i64 4853321196694829351, ; 187: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 109
	i64 5055365687667823624, ; 188: Xamarin.AndroidX.Activity.Ktx.dll => 0x4628444ef7239408 => 224
	i64 5081566143765835342, ; 189: System.Resources.ResourceManager.dll => 0x4685597c05d06e4e => 99
	i64 5099468265966638712, ; 190: System.Resources.ResourceManager => 0x46c4f35ea8519678 => 99
	i64 5103417709280584325, ; 191: System.Collections.Specialized => 0x46d2fb5e161b6285 => 11
	i64 5182934613077526976, ; 192: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 11
	i64 5197073077358930460, ; 193: Microsoft.AspNetCore.Components.Web.dll => 0x481fb66db7b9aa1c => 179
	i64 5205316157927637098, ; 194: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 266
	i64 5244375036463807528, ; 195: System.Diagnostics.Contracts.dll => 0x48c7c34f4d59fc28 => 25
	i64 5262971552273843408, ; 196: System.Security.Principal.dll => 0x4909d4be0c44c4d0 => 128
	i64 5275249672021082215, ; 197: BlazingQuiz.Shared => 0x493573a092500067 => 337
	i64 5278787618751394462, ; 198: System.Net.WebClient.dll => 0x4942055efc68329e => 76
	i64 5280980186044710147, ; 199: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x4949cf7fd7123d03 => 258
	i64 5290786973231294105, ; 200: System.Runtime.Loader => 0x496ca6b869b72699 => 109
	i64 5376510917114486089, ; 201: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 284
	i64 5408338804355907810, ; 202: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 282
	i64 5423376490970181369, ; 203: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 106
	i64 5440320908473006344, ; 204: Microsoft.VisualBasic.Core => 0x4b7fe70acda9f908 => 2
	i64 5446034149219586269, ; 205: System.Diagnostics.Debug => 0x4b94333452e150dd => 26
	i64 5451019430259338467, ; 206: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 237
	i64 5457765010617926378, ; 207: System.Xml.Serialization => 0x4bbde05c557002ea => 157
	i64 5471532531798518949, ; 208: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 328
	i64 5507995362134886206, ; 209: System.Core.dll => 0x4c705499688c873e => 21
	i64 5522859530602327440, ; 210: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 331
	i64 5527431512186326818, ; 211: System.IO.FileSystem.Primitives.dll => 0x4cb561acbc2a8f22 => 49
	i64 5570799893513421663, ; 212: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 43
	i64 5573260873512690141, ; 213: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 126
	i64 5574231584441077149, ; 214: Xamarin.AndroidX.Annotation.Jvm => 0x4d5ba617ae5f8d9d => 227
	i64 5591791169662171124, ; 215: System.Linq.Parallel => 0x4d9a087135e137f4 => 59
	i64 5650097808083101034, ; 216: System.Security.Cryptography.Algorithms.dll => 0x4e692e055d01a56a => 119
	i64 5692067934154308417, ; 217: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 287
	i64 5724799082821825042, ; 218: Xamarin.AndroidX.ExifInterface => 0x4f72926f3e13b212 => 250
	i64 5757522595884336624, ; 219: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 236
	i64 5783556987928984683, ; 220: Microsoft.VisualBasic => 0x504352701bbc3c6b => 3
	i64 5896680224035167651, ; 221: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 256
	i64 5959344983920014087, ; 222: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x52b3d8b05c8ef307 => 276
	i64 5979151488806146654, ; 223: System.Formats.Asn1 => 0x52fa3699a489d25e => 38
	i64 5984759512290286505, ; 224: System.Security.Cryptography.Primitives => 0x530e23115c33dba9 => 124
	i64 6010974535988770325, ; 225: Microsoft.Extensions.Diagnostics.dll => 0x536b457e33877615 => 190
	i64 6068057819846744445, ; 226: ro/Microsoft.Maui.Controls.resources.dll => 0x5436126fec7f197d => 325
	i64 6102788177522843259, ; 227: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0x54b1758374b3de7b => 276
	i64 6182525717148725503, ; 228: Microsoft.AspNetCore.Components.Authorization => 0x55ccbe62215df0ff => 176
	i64 6200764641006662125, ; 229: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 325
	i64 6222399776351216807, ; 230: System.Text.Json.dll => 0x565a67a0ffe264a7 => 137
	i64 6251069312384999852, ; 231: System.Transactions.Local => 0x56c0426b870da1ac => 149
	i64 6278736998281604212, ; 232: System.Private.DataContractSerialization => 0x57228e08a4ad6c74 => 85
	i64 6284145129771520194, ; 233: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 90
	i64 6319713645133255417, ; 234: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 260
	i64 6338814580921602490, ; 235: BlazingQuiz.Shared.dll => 0x57f7fe46e0e611ba => 337
	i64 6357457916754632952, ; 236: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 341
	i64 6368328068195438891, ; 237: Refit.HttpClientFactory => 0x5860d8a31df0512b => 216
	i64 6401687960814735282, ; 238: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 257
	i64 6478287442656530074, ; 239: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 313
	i64 6504860066809920875, ; 240: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 232
	i64 6548213210057960872, ; 241: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 243
	i64 6557084851308642443, ; 242: Xamarin.AndroidX.Window.dll => 0x5aff71ee6c58c08b => 288
	i64 6560151584539558821, ; 243: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 201
	i64 6589202984700901502, ; 244: Xamarin.Google.ErrorProne.Annotations.dll => 0x5b718d34180a787e => 293
	i64 6591971792923354531, ; 245: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x5b7b636b7e9765a3 => 258
	i64 6617685658146568858, ; 246: System.Text.Encoding.CodePages => 0x5bd6be0b4905fa9a => 133
	i64 6713440830605852118, ; 247: System.Reflection.TypeExtensions.dll => 0x5d2aeeddb8dd7dd6 => 96
	i64 6739853162153639747, ; 248: Microsoft.VisualBasic.dll => 0x5d88c4bde075ff43 => 3
	i64 6743165466166707109, ; 249: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 321
	i64 6772837112740759457, ; 250: System.Runtime.InteropServices.JavaScript => 0x5dfdf378527ec7a1 => 105
	i64 6777482997383978746, ; 251: pt/Microsoft.Maui.Controls.resources.dll => 0x5e0e74e0a2525efa => 324
	i64 6786606130239981554, ; 252: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 33
	i64 6798329586179154312, ; 253: System.Windows => 0x5e5884bd523ca188 => 154
	i64 6814185388980153342, ; 254: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 158
	i64 6876862101832370452, ; 255: System.Xml.Linq => 0x5f6f85a57d108914 => 155
	i64 6894844156784520562, ; 256: System.Numerics.Vectors => 0x5faf683aead1ad72 => 82
	i64 6920570528939222495, ; 257: Microsoft.AspNetCore.Components.WebView => 0x600ace3ab475a5df => 180
	i64 7011053663211085209, ; 258: Xamarin.AndroidX.Fragment.Ktx => 0x614c442918e5dd99 => 252
	i64 7060896174307865760, ; 259: System.Threading.Tasks.Parallel.dll => 0x61fd57a90988f4a0 => 143
	i64 7083547580668757502, ; 260: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 87
	i64 7101497697220435230, ; 261: System.Configuration => 0x628d9687c0141d1e => 19
	i64 7103753931438454322, ; 262: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 253
	i64 7112547816752919026, ; 263: System.IO.FileSystem => 0x62b4d88e3189b1f2 => 51
	i64 7192745174564810625, ; 264: Xamarin.Android.Glide.GifDecoder.dll => 0x63d1c3a0a1d72f81 => 222
	i64 7220009545223068405, ; 265: sv/Microsoft.Maui.Controls.resources.dll => 0x6432a06d99f35af5 => 328
	i64 7270811800166795866, ; 266: System.Linq => 0x64e71ccf51a90a5a => 61
	i64 7299370801165188114, ; 267: System.IO.Pipes.AccessControl.dll => 0x654c9311e74f3c12 => 54
	i64 7316205155833392065, ; 268: Microsoft.Win32.Primitives => 0x658861d38954abc1 => 4
	i64 7338192458477945005, ; 269: System.Reflection => 0x65d67f295d0740ad => 97
	i64 7349431895026339542, ; 270: Xamarin.Android.Glide.DiskLruCache => 0x65fe6d5e9bf88ed6 => 221
	i64 7377312882064240630, ; 271: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 17
	i64 7488575175965059935, ; 272: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 155
	i64 7489048572193775167, ; 273: System.ObjectModel => 0x67ee71ff6b419e3f => 84
	i64 7496222613193209122, ; 274: System.IdentityModel.Tokens.Jwt => 0x6807eec000a1b522 => 217
	i64 7592577537120840276, ; 275: System.Diagnostics.Process => 0x695e410af5b2aa54 => 29
	i64 7637303409920963731, ; 276: System.IO.Compression.ZipFile.dll => 0x69fd26fcb637f493 => 45
	i64 7654504624184590948, ; 277: System.Net.Http => 0x6a3a4366801b8264 => 64
	i64 7694700312542370399, ; 278: System.Net.Mail => 0x6ac9112a7e2cda5f => 66
	i64 7708790323521193081, ; 279: ms/Microsoft.Maui.Controls.resources.dll => 0x6afb1ff4d1730479 => 319
	i64 7714652370974252055, ; 280: System.Private.CoreLib => 0x6b0ff375198b9c17 => 172
	i64 7725404731275645577, ; 281: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x6b3626ac11ce9289 => 261
	i64 7735176074855944702, ; 282: Microsoft.CSharp => 0x6b58dda848e391fe => 1
	i64 7735352534559001595, ; 283: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 296
	i64 7791074099216502080, ; 284: System.IO.FileSystem.AccessControl.dll => 0x6c1f749d468bcd40 => 47
	i64 7820441508502274321, ; 285: System.Data => 0x6c87ca1e14ff8111 => 24
	i64 7836164640616011524, ; 286: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 229
	i64 7919757340696389605, ; 287: Microsoft.Extensions.Diagnostics.Abstractions => 0x6de8a157378027e5 => 191
	i64 8014722069583580780, ; 288: Microsoft.AspNetCore.Components.Forms.dll => 0x6f3a03422b034e6c => 177
	i64 8025517457475554965, ; 289: WindowsBase => 0x6f605d9b4786ce95 => 165
	i64 8031450141206250471, ; 290: System.Runtime.Intrinsics.dll => 0x6f757159d9dc03e7 => 108
	i64 8064050204834738623, ; 291: System.Collections.dll => 0x6fe942efa61731bf => 12
	i64 8083354569033831015, ; 292: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 255
	i64 8085230611270010360, ; 293: System.Net.Http.Json.dll => 0x703482674fdd05f8 => 63
	i64 8087206902342787202, ; 294: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 27
	i64 8103644804370223335, ; 295: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 23
	i64 8113615946733131500, ; 296: System.Reflection.Extensions => 0x70995ab73cf916ec => 93
	i64 8167236081217502503, ; 297: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 168
	i64 8185542183669246576, ; 298: System.Collections => 0x7198e33f4794aa70 => 12
	i64 8187640529827139739, ; 299: Xamarin.KotlinX.Coroutines.Android => 0x71a057ae90f0109b => 300
	i64 8246048515196606205, ; 300: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 214
	i64 8264926008854159966, ; 301: System.Diagnostics.Process.dll => 0x72b2ea6a64a3a25e => 29
	i64 8290740647658429042, ; 302: System.Runtime.Extensions => 0x730ea0b15c929a72 => 103
	i64 8318905602908530212, ; 303: System.ComponentModel.DataAnnotations => 0x7372b092055ea624 => 14
	i64 8368701292315763008, ; 304: System.Security.Cryptography => 0x7423997c6fd56140 => 126
	i64 8398329775253868912, ; 305: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 238
	i64 8400357532724379117, ; 306: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 270
	i64 8410671156615598628, ; 307: System.Reflection.Emit.Lightweight.dll => 0x74b8b4daf4b25224 => 91
	i64 8426919725312979251, ; 308: Xamarin.AndroidX.Lifecycle.Process => 0x74f26ed7aa033133 => 259
	i64 8518412311883997971, ; 309: System.Collections.Immutable => 0x76377add7c28e313 => 9
	i64 8526208801455073459, ; 310: BlazingQuiz.Shared.Components.dll => 0x76532dbb2b89e8b3 => 336
	i64 8533585025865342196, ; 311: BlazingQuiz.Mobile.dll => 0x766d625e3f4bdcf4 => 0
	i64 8563666267364444763, ; 312: System.Private.Uri => 0x76d841191140ca5b => 86
	i64 8598790081731763592, ; 313: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x77550a055fc61d88 => 249
	i64 8601935802264776013, ; 314: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 282
	i64 8614108721271900878, ; 315: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x778b763e14018ace => 323
	i64 8623059219396073920, ; 316: System.Net.Quic.dll => 0x77ab42ac514299c0 => 71
	i64 8626175481042262068, ; 317: Java.Interop => 0x77b654e585b55834 => 168
	i64 8638972117149407195, ; 318: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 1
	i64 8639588376636138208, ; 319: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 269
	i64 8648495978913578441, ; 320: Microsoft.Win32.Registry.dll => 0x7805a1456889bdc9 => 5
	i64 8677882282824630478, ; 321: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 323
	i64 8684531736582871431, ; 322: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 44
	i64 8725526185868997716, ; 323: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 27
	i64 8816904670177563593, ; 324: Microsoft.Extensions.Diagnostics => 0x7a5bf015646a93c9 => 190
	i64 8853378295825400934, ; 325: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 297
	i64 8941376889969657626, ; 326: System.Xml.XDocument => 0x7c1626e87187471a => 158
	i64 8951477988056063522, ; 327: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0x7c3a09cd9ccf5e22 => 272
	i64 8954753533646919997, ; 328: System.Runtime.Serialization.Json => 0x7c45ace50032d93d => 112
	i64 9045785047181495996, ; 329: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 333
	i64 9138683372487561558, ; 330: System.Security.Cryptography.Csp => 0x7ed3201bc3e3d156 => 121
	i64 9312692141327339315, ; 331: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 287
	i64 9324707631942237306, ; 332: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 228
	i64 9427266486299436557, ; 333: Microsoft.IdentityModel.Logging.dll => 0x82d460ebe6d2a60d => 206
	i64 9468215723722196442, ; 334: System.Xml.XPath.XDocument.dll => 0x8365dc09353ac5da => 159
	i64 9534752168001869100, ; 335: BlazingQuiz.Mobile => 0x84523e945b23152c => 0
	i64 9554839972845591462, ; 336: System.ServiceModel.Web => 0x84999c54e32a1ba6 => 131
	i64 9575902398040817096, ; 337: Xamarin.Google.Crypto.Tink.Android.dll => 0x84e4707ee708bdc8 => 292
	i64 9584643793929893533, ; 338: System.IO.dll => 0x85037ebfbbd7f69d => 57
	i64 9650158550865574924, ; 339: Microsoft.Extensions.Configuration.Json => 0x85ec4012c28a7c0c => 187
	i64 9659729154652888475, ; 340: System.Text.RegularExpressions => 0x860e407c9991dd9b => 138
	i64 9662334977499516867, ; 341: System.Numerics.dll => 0x8617827802b0cfc3 => 83
	i64 9667360217193089419, ; 342: System.Diagnostics.StackTrace => 0x86295ce5cd89898b => 30
	i64 9678050649315576968, ; 343: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 239
	i64 9702891218465930390, ; 344: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 10
	i64 9780093022148426479, ; 345: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x87b9dec9576efaef => 289
	i64 9808709177481450983, ; 346: Mono.Android.dll => 0x881f890734e555e7 => 171
	i64 9825649861376906464, ; 347: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 236
	i64 9834056768316610435, ; 348: System.Transactions.dll => 0x8879968718899783 => 150
	i64 9836529246295212050, ; 349: System.Reflection.Metadata => 0x88825f3bbc2ac012 => 94
	i64 9907349773706910547, ; 350: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x897dfa20b758db53 => 249
	i64 9933555792566666578, ; 351: System.Linq.Queryable.dll => 0x89db145cf475c552 => 60
	i64 9956195530459977388, ; 352: Microsoft.Maui => 0x8a2b8315b36616ac => 212
	i64 9974604633896246661, ; 353: System.Xml.Serialization.dll => 0x8a6cea111a59dd85 => 157
	i64 9991543690424095600, ; 354: es/Microsoft.Maui.Controls.resources.dll => 0x8aa9180c89861370 => 308
	i64 10017511394021241210, ; 355: Microsoft.Extensions.Logging.Debug => 0x8b055989ae10717a => 200
	i64 10038780035334861115, ; 356: System.Net.Http.dll => 0x8b50e941206af13b => 64
	i64 10051358222726253779, ; 357: System.Private.Xml => 0x8b7d990c97ccccd3 => 88
	i64 10078727084704864206, ; 358: System.Net.WebSockets.Client => 0x8bded4e257f117ce => 79
	i64 10089571585547156312, ; 359: System.IO.FileSystem.AccessControl => 0x8c055be67469bb58 => 47
	i64 10092835686693276772, ; 360: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 210
	i64 10105485790837105934, ; 361: System.Threading.Tasks.Parallel => 0x8c3de5c91d9a650e => 143
	i64 10143853363526200146, ; 362: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 305
	i64 10205853378024263619, ; 363: Microsoft.Extensions.Configuration.Binder => 0x8da279930adb4fc3 => 185
	i64 10226222362177979215, ; 364: Xamarin.Kotlin.StdLib.Jdk7 => 0x8dead70ebbc6434f => 298
	i64 10229024438826829339, ; 365: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 243
	i64 10236703004850800690, ; 366: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 74
	i64 10245369515835430794, ; 367: System.Reflection.Emit.Lightweight => 0x8e2edd4ad7fc978a => 91
	i64 10252714262739571204, ; 368: Microsoft.Maui.Controls.HotReload.Forms => 0x8e48f54cfe2c5204 => 338
	i64 10321854143672141184, ; 369: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 295
	i64 10360651442923773544, ; 370: System.Text.Encoding => 0x8fc86d98211c1e68 => 135
	i64 10364469296367737616, ; 371: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 90
	i64 10376576884623852283, ; 372: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 281
	i64 10406448008575299332, ; 373: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 301
	i64 10430153318873392755, ; 374: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 240
	i64 10506226065143327199, ; 375: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 303
	i64 10546663366131771576, ; 376: System.Runtime.Serialization.Json.dll => 0x925d4673efe8e8b8 => 112
	i64 10566960649245365243, ; 377: System.Globalization.dll => 0x92a562b96dcd13fb => 42
	i64 10595762989148858956, ; 378: System.Xml.XPath.XDocument => 0x930bb64cc472ea4c => 159
	i64 10670374202010151210, ; 379: Microsoft.Win32.Primitives.dll => 0x9414c8cd7b4ea92a => 4
	i64 10714184849103829812, ; 380: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 103
	i64 10734191584620811116, ; 381: Microsoft.Extensions.FileProviders.Embedded.dll => 0x94f7825fc04f936c => 194
	i64 10785150219063592792, ; 382: System.Net.Primitives => 0x95ac8cfb68830758 => 70
	i64 10809043855025277762, ; 383: Microsoft.Extensions.Options.ConfigurationExtensions => 0x9601701e0c668b42 => 202
	i64 10822644899632537592, ; 384: System.Linq.Queryable => 0x9631c23204ca5ff8 => 60
	i64 10830817578243619689, ; 385: System.Formats.Tar => 0x964ecb340a447b69 => 39
	i64 10847732767863316357, ; 386: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 230
	i64 10899834349646441345, ; 387: System.Web => 0x9743fd975946eb81 => 153
	i64 10943875058216066601, ; 388: System.IO.UnmanagedMemoryStream.dll => 0x97e07461df39de29 => 56
	i64 10964653383833615866, ; 389: System.Diagnostics.Tracing => 0x982a4628ccaffdfa => 34
	i64 11002576679268595294, ; 390: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 199
	i64 11009005086950030778, ; 391: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 212
	i64 11019817191295005410, ; 392: Xamarin.AndroidX.Annotation.Jvm.dll => 0x98ee415998e1b2e2 => 227
	i64 11023048688141570732, ; 393: System.Core => 0x98f9bc61168392ac => 21
	i64 11037814507248023548, ; 394: System.Xml => 0x992e31d0412bf7fc => 163
	i64 11051904132540108364, ; 395: Microsoft.Extensions.FileProviders.Composite.dll => 0x99604040c7b98e4c => 193
	i64 11071824625609515081, ; 396: Xamarin.Google.ErrorProne.Annotations => 0x99a705d600e0a049 => 293
	i64 11103970607964515343, ; 397: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 314
	i64 11136029745144976707, ; 398: Jsr305Binding.dll => 0x9a8b200d4f8cd543 => 291
	i64 11162124722117608902, ; 399: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 286
	i64 11188319605227840848, ; 400: System.Threading.Overlapped => 0x9b44e5671724e550 => 140
	i64 11218356222449480316, ; 401: Microsoft.AspNetCore.Components => 0x9baf9b8c02e4f27c => 175
	i64 11220793807500858938, ; 402: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 317
	i64 11226290749488709958, ; 403: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 201
	i64 11235648312900863002, ; 404: System.Reflection.DispatchProxy.dll => 0x9bed0a9c8fac441a => 89
	i64 11329751333533450475, ; 405: System.Threading.Timer.dll => 0x9d3b5ccf6cc500eb => 147
	i64 11340910727871153756, ; 406: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 242
	i64 11347436699239206956, ; 407: System.Xml.XmlSerializer.dll => 0x9d7a318e8162502c => 162
	i64 11392833485892708388, ; 408: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 271
	i64 11432101114902388181, ; 409: System.AppContext => 0x9ea6fb64e61a9dd5 => 6
	i64 11446671985764974897, ; 410: Mono.Android.Export => 0x9edabf8623efc131 => 169
	i64 11448276831755070604, ; 411: System.Diagnostics.TextWriterTraceListener => 0x9ee0731f77186c8c => 31
	i64 11485890710487134646, ; 412: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 107
	i64 11508496261504176197, ; 413: Xamarin.AndroidX.Fragment.Ktx.dll => 0x9fb664600dde1045 => 252
	i64 11513602507638267977, ; 414: System.IO.Pipelines.dll => 0x9fc8887aa0d36049 => 218
	i64 11517440453979132662, ; 415: Microsoft.IdentityModel.Abstractions.dll => 0x9fd62b122523d2f6 => 204
	i64 11518296021396496455, ; 416: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 315
	i64 11529969570048099689, ; 417: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 286
	i64 11530571088791430846, ; 418: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 198
	i64 11580057168383206117, ; 419: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 225
	i64 11591352189662810718, ; 420: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0xa0dcc167234c525e => 279
	i64 11597940890313164233, ; 421: netstandard => 0xa0f429ca8d1805c9 => 167
	i64 11672361001936329215, ; 422: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 253
	i64 11692977985522001935, ; 423: System.Threading.Overlapped.dll => 0xa245cd869980680f => 140
	i64 11705530742807338875, ; 424: he/Microsoft.Maui.Controls.resources.dll => 0xa272663128721f7b => 311
	i64 11707554492040141440, ; 425: System.Linq.Parallel.dll => 0xa27996c7fe94da80 => 59
	i64 11743665907891708234, ; 426: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 144
	i64 11991047634523762324, ; 427: System.Net => 0xa668c24ad493ae94 => 81
	i64 12040886584167504988, ; 428: System.Net.ServicePoint => 0xa719d28d8e121c5c => 74
	i64 12048689113179125827, ; 429: Microsoft.Extensions.FileProviders.Physical => 0xa7358ae968287843 => 195
	i64 12058074296353848905, ; 430: Microsoft.Extensions.FileSystemGlobbing.dll => 0xa756e2afa5707e49 => 196
	i64 12063623837170009990, ; 431: System.Security => 0xa76a99f6ce740786 => 130
	i64 12096697103934194533, ; 432: System.Diagnostics.Contracts => 0xa7e019eccb7e8365 => 25
	i64 12102847907131387746, ; 433: System.Buffers => 0xa7f5f40c43256f62 => 7
	i64 12123043025855404482, ; 434: System.Reflection.Extensions.dll => 0xa83db366c0e359c2 => 93
	i64 12137774235383566651, ; 435: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 283
	i64 12145679461940342714, ; 436: System.Text.Json => 0xa88e1f1ebcb62fba => 137
	i64 12151334981087501243, ; 437: Refit.HttpClientFactory.dll => 0xa8a236c8e67f9bbb => 216
	i64 12191646537372739477, ; 438: Xamarin.Android.Glide.dll => 0xa9316dee7f392795 => 219
	i64 12201331334810686224, ; 439: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 113
	i64 12269460666702402136, ; 440: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 9
	i64 12313367145828839434, ; 441: System.IO.Pipelines => 0xaae1de2e1c17f00a => 218
	i64 12332222936682028543, ; 442: System.Runtime.Handles => 0xab24db6c07db5dff => 104
	i64 12375446203996702057, ; 443: System.Configuration.dll => 0xabbe6ac12e2e0569 => 19
	i64 12439275739440478309, ; 444: Microsoft.IdentityModel.JsonWebTokens => 0xaca12f61007bf865 => 205
	i64 12451044538927396471, ; 445: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 251
	i64 12459959602091767212, ; 446: Microsoft.AspNetCore.Components.Authorization.dll => 0xaceaab3e0e65b5ac => 176
	i64 12466513435562512481, ; 447: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 265
	i64 12475113361194491050, ; 448: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 341
	i64 12487638416075308985, ; 449: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 245
	i64 12517810545449516888, ; 450: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 33
	i64 12538491095302438457, ; 451: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 233
	i64 12550732019250633519, ; 452: System.IO.Compression => 0xae2d28465e8e1b2f => 46
	i64 12681088699309157496, ; 453: it/Microsoft.Maui.Controls.resources.dll => 0xaffc46fc178aec78 => 316
	i64 12699999919562409296, ; 454: System.Diagnostics.StackTrace.dll => 0xb03f76a3ad01c550 => 30
	i64 12700543734426720211, ; 455: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 234
	i64 12708238894395270091, ; 456: System.IO => 0xb05cbbf17d3ba3cb => 57
	i64 12708922737231849740, ; 457: System.Text.Encoding.Extensions => 0xb05f29e50e96e90c => 134
	i64 12717050818822477433, ; 458: System.Runtime.Serialization.Xml.dll => 0xb07c0a5786811679 => 114
	i64 12753841065332862057, ; 459: Xamarin.AndroidX.Window => 0xb0febee04cf46c69 => 288
	i64 12823819093633476069, ; 460: th/Microsoft.Maui.Controls.resources.dll => 0xb1f75b85abe525e5 => 329
	i64 12828192437253469131, ; 461: Xamarin.Kotlin.StdLib.Jdk8.dll => 0xb206e50e14d873cb => 299
	i64 12835242264250840079, ; 462: System.IO.Pipes => 0xb21ff0d5d6c0740f => 55
	i64 12843321153144804894, ; 463: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 203
	i64 12843770487262409629, ; 464: System.AppContext.dll => 0xb23e3d357debf39d => 6
	i64 12859557719246324186, ; 465: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 77
	i64 12982280885948128408, ; 466: Xamarin.AndroidX.CustomView.PoolingContainer => 0xb42a53aec5481c98 => 244
	i64 13003699287675270979, ; 467: Microsoft.AspNetCore.Components.WebView.Maui => 0xb4766b9b07e27743 => 181
	i64 13068258254871114833, ; 468: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 111
	i64 13129914918964716986, ; 469: Xamarin.AndroidX.Emoji2.dll => 0xb636d40db3fe65ba => 248
	i64 13173818576982874404, ; 470: System.Runtime.CompilerServices.VisualC.dll => 0xb6d2ce32a8819924 => 102
	i64 13221551921002590604, ; 471: ca/Microsoft.Maui.Controls.resources.dll => 0xb77c636bdebe318c => 303
	i64 13222659110913276082, ; 472: ja/Microsoft.Maui.Controls.resources.dll => 0xb78052679c1178b2 => 317
	i64 13343850469010654401, ; 473: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 170
	i64 13370592475155966277, ; 474: System.Runtime.Serialization => 0xb98de304062ea945 => 115
	i64 13381594904270902445, ; 475: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 311
	i64 13401370062847626945, ; 476: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 283
	i64 13404347523447273790, ; 477: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 238
	i64 13431476299110033919, ; 478: System.Net.WebClient => 0xba663087f18829ff => 76
	i64 13454009404024712428, ; 479: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 294
	i64 13463706743370286408, ; 480: System.Private.DataContractSerialization.dll => 0xbad8b1f3069e0548 => 85
	i64 13465488254036897740, ; 481: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 296
	i64 13467053111158216594, ; 482: uk/Microsoft.Maui.Controls.resources.dll => 0xbae49573fde79792 => 331
	i64 13491513212026656886, ; 483: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 231
	i64 13540124433173649601, ; 484: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 332
	i64 13545416393490209236, ; 485: id/Microsoft.Maui.Controls.resources.dll => 0xbbfafc7174bc99d4 => 315
	i64 13550417756503177631, ; 486: Microsoft.Extensions.FileProviders.Abstractions.dll => 0xbc0cc1280684799f => 192
	i64 13572454107664307259, ; 487: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 273
	i64 13578472628727169633, ; 488: System.Xml.XPath => 0xbc706ce9fba5c261 => 160
	i64 13580399111273692417, ; 489: Microsoft.VisualBasic.Core.dll => 0xbc77450a277fbd01 => 2
	i64 13621154251410165619, ; 490: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0xbd080f9faa1acf73 => 244
	i64 13647894001087880694, ; 491: System.Data.dll => 0xbd670f48cb071df6 => 24
	i64 13675589307506966157, ; 492: Xamarin.AndroidX.Activity.Ktx => 0xbdc97404d0153e8d => 224
	i64 13702626353344114072, ; 493: System.Diagnostics.Tools.dll => 0xbe29821198fb6d98 => 32
	i64 13710614125866346983, ; 494: System.Security.AccessControl.dll => 0xbe45e2e7d0b769e7 => 117
	i64 13713329104121190199, ; 495: System.Dynamic.Runtime => 0xbe4f8829f32b5737 => 37
	i64 13717397318615465333, ; 496: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 16
	i64 13755568601956062840, ; 497: fr/Microsoft.Maui.Controls.resources.dll => 0xbee598c36b1b9678 => 310
	i64 13768883594457632599, ; 498: System.IO.IsolatedStorage => 0xbf14e6adb159cf57 => 52
	i64 13814445057219246765, ; 499: hr/Microsoft.Maui.Controls.resources.dll => 0xbfb6c49664b43aad => 313
	i64 13828521679616088467, ; 500: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 297
	i64 13881769479078963060, ; 501: System.Console.dll => 0xc0a5f3cade5c6774 => 20
	i64 13911222732217019342, ; 502: System.Security.Cryptography.OpenSsl.dll => 0xc10e975ec1226bce => 123
	i64 13928444506500929300, ; 503: System.Windows.dll => 0xc14bc67b8bba9714 => 154
	i64 13959074834287824816, ; 504: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 251
	i64 14075334701871371868, ; 505: System.ServiceModel.Web.dll => 0xc355a25647c5965c => 131
	i64 14082136096249122791, ; 506: Microsoft.AspNetCore.Metadata => 0xc36dcc2b4fa28fe7 => 182
	i64 14100563506285742564, ; 507: da/Microsoft.Maui.Controls.resources.dll => 0xc3af43cd0cff89e4 => 305
	i64 14124974489674258913, ; 508: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 233
	i64 14125464355221830302, ; 509: System.Threading.dll => 0xc407bafdbc707a9e => 148
	i64 14178052285788134900, ; 510: Xamarin.Android.Glide.Annotations.dll => 0xc4c28f6f75511df4 => 220
	i64 14212104595480609394, ; 511: System.Security.Cryptography.Cng.dll => 0xc53b89d4a4518272 => 120
	i64 14220608275227875801, ; 512: System.Diagnostics.FileVersionInfo.dll => 0xc559bfe1def019d9 => 28
	i64 14226382999226559092, ; 513: System.ServiceProcess => 0xc56e43f6938e2a74 => 132
	i64 14232023429000439693, ; 514: System.Resources.Writer.dll => 0xc5824de7789ba78d => 100
	i64 14254574811015963973, ; 515: System.Text.Encoding.Extensions.dll => 0xc5d26c4442d66545 => 134
	i64 14261073672896646636, ; 516: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 271
	i64 14298246716367104064, ; 517: System.Web.dll => 0xc66d93a217f4e840 => 153
	i64 14327695147300244862, ; 518: System.Reflection.dll => 0xc6d632d338eb4d7e => 97
	i64 14327709162229390963, ; 519: System.Security.Cryptography.X509Certificates => 0xc6d63f9253cade73 => 125
	i64 14331727281556788554, ; 520: Xamarin.Android.Glide.DiskLruCache.dll => 0xc6e48607a2f7954a => 221
	i64 14346402571976470310, ; 521: System.Net.Ping.dll => 0xc718a920f3686f26 => 69
	i64 14461014870687870182, ; 522: System.Net.Requests.dll => 0xc8afd8683afdece6 => 72
	i64 14464374589798375073, ; 523: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 326
	i64 14486659737292545672, ; 524: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 256
	i64 14495724990987328804, ; 525: Xamarin.AndroidX.ResourceInspection.Annotation => 0xc92b2913e18d5d24 => 274
	i64 14522721392235705434, ; 526: el/Microsoft.Maui.Controls.resources.dll => 0xc98b12295c2cf45a => 307
	i64 14551742072151931844, ; 527: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 136
	i64 14561513370130550166, ; 528: System.Security.Cryptography.Primitives.dll => 0xca14e3428abb8d96 => 124
	i64 14574160591280636898, ; 529: System.Net.Quic => 0xca41d1d72ec783e2 => 71
	i64 14622043554576106986, ; 530: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 111
	i64 14644440854989303794, ; 531: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 266
	i64 14669215534098758659, ; 532: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 188
	i64 14690985099581930927, ; 533: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 152
	i64 14705122255218365489, ; 534: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 318
	i64 14744092281598614090, ; 535: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 334
	i64 14792063746108907174, ; 536: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 294
	i64 14832630590065248058, ; 537: System.Security.Claims => 0xcdd816ef5d6e873a => 118
	i64 14852515768018889994, ; 538: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 242
	i64 14889905118082851278, ; 539: GoogleGson.dll => 0xcea391d0969961ce => 173
	i64 14892012299694389861, ; 540: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xceab0e490a083a65 => 335
	i64 14904040806490515477, ; 541: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 302
	i64 14912225920358050525, ; 542: System.Security.Principal.Windows => 0xcef2de7759506add => 127
	i64 14935719434541007538, ; 543: System.Text.Encoding.CodePages.dll => 0xcf4655b160b702b2 => 133
	i64 14954917835170835695, ; 544: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 189
	i64 14984936317414011727, ; 545: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 77
	i64 14987728460634540364, ; 546: System.IO.Compression.dll => 0xcfff1ba06622494c => 46
	i64 14988210264188246988, ; 547: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 245
	i64 15015154896917945444, ; 548: System.Net.Security.dll => 0xd0608bd33642dc64 => 73
	i64 15024878362326791334, ; 549: System.Net.Http.Json => 0xd0831743ebf0f4a6 => 63
	i64 15051741671811457419, ; 550: Microsoft.Extensions.Diagnostics.Abstractions.dll => 0xd0e2874d8f44218b => 191
	i64 15071021337266399595, ; 551: System.Resources.Reader.dll => 0xd127060e7a18a96b => 98
	i64 15076659072870671916, ; 552: System.ObjectModel.dll => 0xd13b0d8c1620662c => 84
	i64 15111608613780139878, ; 553: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 319
	i64 15115185479366240210, ; 554: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 43
	i64 15133485256822086103, ; 555: System.Linq.dll => 0xd204f0a9127dd9d7 => 61
	i64 15138356091203993725, ; 556: Microsoft.IdentityModel.Abstractions => 0xd2163ea89395c07d => 204
	i64 15150743910298169673, ; 557: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xd2424150783c3149 => 272
	i64 15227001540531775957, ; 558: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 184
	i64 15234786388537674379, ; 559: System.Dynamic.Runtime.dll => 0xd36cd580c5be8a8b => 37
	i64 15250465174479574862, ; 560: System.Globalization.Calendars.dll => 0xd3a489469852174e => 40
	i64 15272359115529052076, ; 561: Xamarin.AndroidX.Collection.Ktx => 0xd3f251b2fb4edfac => 235
	i64 15279429628684179188, ; 562: Xamarin.KotlinX.Coroutines.Android.dll => 0xd40b704b1c4c96f4 => 300
	i64 15299439993936780255, ; 563: System.Xml.XPath.dll => 0xd452879d55019bdf => 160
	i64 15338463749992804988, ; 564: System.Resources.Reader => 0xd4dd2b839286f27c => 98
	i64 15370334346939861994, ; 565: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 240
	i64 15391712275433856905, ; 566: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 189
	i64 15427448221306938193, ; 567: Microsoft.AspNetCore.Components.Web => 0xd6194e6b4dbb6351 => 179
	i64 15481710163200268842, ; 568: Microsoft.Extensions.FileProviders.Composite => 0xd6da155e291b5a2a => 193
	i64 15526743539506359484, ; 569: System.Text.Encoding.dll => 0xd77a12fc26de2cbc => 135
	i64 15527772828719725935, ; 570: System.Console => 0xd77dbb1e38cd3d6f => 20
	i64 15530465045505749832, ; 571: System.Net.HttpListener.dll => 0xd7874bacc9fdb348 => 65
	i64 15536481058354060254, ; 572: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 306
	i64 15541854775306130054, ; 573: System.Security.Cryptography.X509Certificates.dll => 0xd7afc292e8d49286 => 125
	i64 15557562860424774966, ; 574: System.Net.Sockets => 0xd7e790fe7a6dc536 => 75
	i64 15582737692548360875, ; 575: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 264
	i64 15592226634512578529, ; 576: Microsoft.AspNetCore.Authorization.dll => 0xd862b7834f81b7e1 => 174
	i64 15609085926864131306, ; 577: System.dll => 0xd89e9cf3334914ea => 164
	i64 15661133872274321916, ; 578: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 156
	i64 15664356999916475676, ; 579: de/Microsoft.Maui.Controls.resources.dll => 0xd962f9b2b6ecd51c => 306
	i64 15710114879900314733, ; 580: Microsoft.Win32.Registry => 0xda058a3f5d096c6d => 5
	i64 15743187114543869802, ; 581: hu/Microsoft.Maui.Controls.resources.dll => 0xda7b09450ae4ef6a => 314
	i64 15755368083429170162, ; 582: System.IO.FileSystem.Primitives => 0xdaa64fcbde529bf2 => 49
	i64 15777549416145007739, ; 583: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 278
	i64 15783653065526199428, ; 584: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 307
	i64 15817206913877585035, ; 585: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 144
	i64 15827202283623377193, ; 586: Microsoft.Extensions.Configuration.Json.dll => 0xdba5849eef9f6929 => 187
	i64 15847085070278954535, ; 587: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 139
	i64 15885744048853936810, ; 588: System.Resources.Writer => 0xdc75800bd0b6eaaa => 100
	i64 15928521404965645318, ; 589: Microsoft.Maui.Controls.Compatibility => 0xdd0d79d32c2eec06 => 209
	i64 15934062614519587357, ; 590: System.Security.Cryptography.OpenSsl => 0xdd2129868f45a21d => 123
	i64 15937190497610202713, ; 591: System.Security.Cryptography.Cng => 0xdd2c465197c97e59 => 120
	i64 15963349826457351533, ; 592: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 142
	i64 15971679995444160383, ; 593: System.Formats.Tar.dll => 0xdda6ce5592a9677f => 39
	i64 16018552496348375205, ; 594: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 68
	i64 16054465462676478687, ; 595: System.Globalization.Extensions => 0xdecceb47319bdadf => 41
	i64 16154507427712707110, ; 596: System => 0xe03056ea4e39aa26 => 164
	i64 16219561732052121626, ; 597: System.Net.Security => 0xe1177575db7c781a => 73
	i64 16252599826146587709, ; 598: Refit.dll => 0xe18cd56e920af43d => 215
	i64 16288847719894691167, ; 599: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 320
	i64 16315482530584035869, ; 600: WindowsBase.dll => 0xe26c3ceb1e8d821d => 165
	i64 16321164108206115771, ; 601: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 199
	i64 16337011941688632206, ; 602: System.Security.Principal.Windows.dll => 0xe2b8b9cdc3aa638e => 127
	i64 16361933716545543812, ; 603: Xamarin.AndroidX.ExifInterface.dll => 0xe3114406a52f1e84 => 250
	i64 16423015068819898779, ; 604: Xamarin.Kotlin.StdLib.Jdk8 => 0xe3ea453135e5c19b => 299
	i64 16454459195343277943, ; 605: System.Net.NetworkInformation => 0xe459fb756d988f77 => 68
	i64 16496768397145114574, ; 606: Mono.Android.Export.dll => 0xe4f04b741db987ce => 169
	i64 16558262036769511634, ; 607: Microsoft.Extensions.Http => 0xe5cac397cf7b98d2 => 197
	i64 16589693266713801121, ; 608: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xe63a6e214f2a71a1 => 263
	i64 16621146507174665210, ; 609: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 237
	i64 16649148416072044166, ; 610: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 214
	i64 16677317093839702854, ; 611: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 270
	i64 16702652415771857902, ; 612: System.ValueTuple => 0xe7cbbde0b0e6d3ee => 151
	i64 16709499819875633724, ; 613: System.IO.Compression.ZipFile => 0xe7e4118e32240a3c => 45
	i64 16737807731308835127, ; 614: System.Runtime.Intrinsics => 0xe848a3736f733137 => 108
	i64 16758309481308491337, ; 615: System.IO.FileSystem.DriveInfo => 0xe89179af15740e49 => 48
	i64 16762783179241323229, ; 616: System.Reflection.TypeExtensions => 0xe8a15e7d0d927add => 96
	i64 16765015072123548030, ; 617: System.Diagnostics.TextWriterTraceListener.dll => 0xe8a94c621bfe717e => 31
	i64 16822611501064131242, ; 618: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 23
	i64 16833383113903931215, ; 619: mscorlib => 0xe99c30c1484d7f4f => 166
	i64 16856067890322379635, ; 620: System.Data.Common.dll => 0xe9ecc87060889373 => 22
	i64 16890310621557459193, ; 621: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 138
	i64 16933958494752847024, ; 622: System.Net.WebProxy.dll => 0xeb018187f0f3b4b0 => 78
	i64 16942731696432749159, ; 623: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 327
	i64 16977952268158210142, ; 624: System.IO.Pipes.AccessControl => 0xeb9dcda2851b905e => 54
	i64 16989020923549080504, ; 625: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xebc52084add25bb8 => 263
	i64 16998075588627545693, ; 626: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 268
	i64 17008137082415910100, ; 627: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 10
	i64 17024911836938395553, ; 628: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 226
	i64 17026344819618783825, ; 629: Microsoft.VisualStudio.DesignTools.TapContract.dll => 0xec49ba676cb0a251 => 340
	i64 17031351772568316411, ; 630: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 267
	i64 17037200463775726619, ; 631: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 254
	i64 17047433665992082296, ; 632: Microsoft.Extensions.Configuration.FileExtensions => 0xec94a699197e4378 => 186
	i64 17062143951396181894, ; 633: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 16
	i64 17079998892748052666, ; 634: Microsoft.AspNetCore.Components.dll => 0xed08587fce5018ba => 175
	i64 17080685096938066842, ; 635: Microsoft.AspNetCore.Components.QuickGrid => 0xed0ac8992b4d539a => 178
	i64 17089008752050867324, ; 636: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xed285aeb25888c7c => 334
	i64 17118171214553292978, ; 637: System.Threading.Channels => 0xed8ff6060fc420b2 => 139
	i64 17137864900836977098, ; 638: Microsoft.IdentityModel.Tokens => 0xedd5ed53b705e9ca => 207
	i64 17187273293601214786, ; 639: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 13
	i64 17201328579425343169, ; 640: System.ComponentModel.EventBasedAsync => 0xeeb76534d96c16c1 => 15
	i64 17202182880784296190, ; 641: System.Security.Cryptography.Encoding.dll => 0xeeba6e30627428fe => 122
	i64 17205988430934219272, ; 642: Microsoft.Extensions.FileSystemGlobbing => 0xeec7f35113509a08 => 196
	i64 17230721278011714856, ; 643: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 87
	i64 17234219099804750107, ; 644: System.Transactions.Local.dll => 0xef2c3ef5e11d511b => 149
	i64 17260702271250283638, ; 645: System.Data.Common => 0xef8a5543bba6bc76 => 22
	i64 17333249706306540043, ; 646: System.Diagnostics.Tracing.dll => 0xf08c12c5bb8b920b => 34
	i64 17338386382517543202, ; 647: System.Net.WebSockets.Client.dll => 0xf09e528d5c6da122 => 79
	i64 17342750010158924305, ; 648: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 312
	i64 17360349973592121190, ; 649: Xamarin.Google.Crypto.Tink.Android => 0xf0ec5a52686b9f66 => 292
	i64 17438153253682247751, ; 650: sk/Microsoft.Maui.Controls.resources.dll => 0xf200c3fe308d7847 => 327
	i64 17470386307322966175, ; 651: System.Threading.Timer => 0xf27347c8d0d5709f => 147
	i64 17509662556995089465, ; 652: System.Net.WebSockets.dll => 0xf2fed1534ea67439 => 80
	i64 17514990004910432069, ; 653: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 310
	i64 17522591619082469157, ; 654: GoogleGson => 0xf32cc03d27a5bf25 => 173
	i64 17590473451926037903, ; 655: Xamarin.Android.Glide => 0xf41dea67fcfda58f => 219
	i64 17623389608345532001, ; 656: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 322
	i64 17627500474728259406, ; 657: System.Globalization => 0xf4a176498a351f4e => 42
	i64 17685921127322830888, ; 658: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 26
	i64 17702523067201099846, ; 659: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xf5abfef008ae1846 => 333
	i64 17704177640604968747, ; 660: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 265
	i64 17710060891934109755, ; 661: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 262
	i64 17712670374920797664, ; 662: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 107
	i64 17777860260071588075, ; 663: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 110
	i64 17790600151040787804, ; 664: Microsoft.IdentityModel.Logging => 0xf6e4e89427cc055c => 206
	i64 17838668724098252521, ; 665: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 7
	i64 17864403808740949822, ; 666: Microsoft.AspNetCore.Components.QuickGrid.dll => 0xf7eb1c9d4823bf3e => 178
	i64 17891337867145587222, ; 667: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 295
	i64 17928294245072900555, ; 668: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 44
	i64 17992315986609351877, ; 669: System.Xml.XmlDocument.dll => 0xf9b18c0ffc6eacc5 => 161
	i64 18025913125965088385, ; 670: System.Threading => 0xfa28e87b91334681 => 148
	i64 18099568558057551825, ; 671: nl/Microsoft.Maui.Controls.resources.dll => 0xfb2e95b53ad977d1 => 321
	i64 18116111925905154859, ; 672: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 231
	i64 18121036031235206392, ; 673: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 267
	i64 18146411883821974900, ; 674: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 38
	i64 18146811631844267958, ; 675: System.ComponentModel.EventBasedAsync.dll => 0xfbd66d08820117b6 => 15
	i64 18225059387460068507, ; 676: System.Threading.ThreadPool.dll => 0xfcec6af3cff4a49b => 146
	i64 18245806341561545090, ; 677: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 8
	i64 18260797123374478311, ; 678: Xamarin.AndroidX.Emoji2 => 0xfd6b623bde35f3e7 => 248
	i64 18305135509493619199, ; 679: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 269
	i64 18318849532986632368, ; 680: System.Security.dll => 0xfe39a097c37fa8b0 => 130
	i64 18324163916253801303, ; 681: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 316
	i64 18380184030268848184, ; 682: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 285
	i64 18439108438687598470 ; 683: System.Reflection.Metadata.dll => 0xffe4df6e2ee1c786 => 94
], align 16

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [684 x i32] [
	i32 247, ; 0
	i32 203, ; 1
	i32 171, ; 2
	i32 213, ; 3
	i32 58, ; 4
	i32 234, ; 5
	i32 151, ; 6
	i32 275, ; 7
	i32 278, ; 8
	i32 241, ; 9
	i32 132, ; 10
	i32 202, ; 11
	i32 340, ; 12
	i32 56, ; 13
	i32 277, ; 14
	i32 309, ; 15
	i32 95, ; 16
	i32 260, ; 17
	i32 186, ; 18
	i32 129, ; 19
	i32 185, ; 20
	i32 194, ; 21
	i32 145, ; 22
	i32 235, ; 23
	i32 18, ; 24
	i32 312, ; 25
	i32 246, ; 26
	i32 261, ; 27
	i32 150, ; 28
	i32 104, ; 29
	i32 95, ; 30
	i32 290, ; 31
	i32 320, ; 32
	i32 36, ; 33
	i32 28, ; 34
	i32 230, ; 35
	i32 268, ; 36
	i32 50, ; 37
	i32 115, ; 38
	i32 70, ; 39
	i32 210, ; 40
	i32 65, ; 41
	i32 170, ; 42
	i32 145, ; 43
	i32 318, ; 44
	i32 289, ; 45
	i32 229, ; 46
	i32 264, ; 47
	i32 254, ; 48
	i32 40, ; 49
	i32 89, ; 50
	i32 81, ; 51
	i32 66, ; 52
	i32 62, ; 53
	i32 86, ; 54
	i32 208, ; 55
	i32 228, ; 56
	i32 106, ; 57
	i32 308, ; 58
	i32 275, ; 59
	i32 102, ; 60
	i32 35, ; 61
	i32 225, ; 62
	i32 330, ; 63
	i32 277, ; 64
	i32 211, ; 65
	i32 330, ; 66
	i32 119, ; 67
	i32 262, ; 68
	i32 304, ; 69
	i32 322, ; 70
	i32 142, ; 71
	i32 141, ; 72
	i32 298, ; 73
	i32 53, ; 74
	i32 35, ; 75
	i32 141, ; 76
	i32 222, ; 77
	i32 232, ; 78
	i32 336, ; 79
	i32 200, ; 80
	i32 246, ; 81
	i32 8, ; 82
	i32 14, ; 83
	i32 181, ; 84
	i32 326, ; 85
	i32 274, ; 86
	i32 51, ; 87
	i32 257, ; 88
	i32 136, ; 89
	i32 101, ; 90
	i32 239, ; 91
	i32 284, ; 92
	i32 116, ; 93
	i32 223, ; 94
	i32 215, ; 95
	i32 163, ; 96
	i32 329, ; 97
	i32 207, ; 98
	i32 166, ; 99
	i32 67, ; 100
	i32 188, ; 101
	i32 304, ; 102
	i32 80, ; 103
	i32 208, ; 104
	i32 101, ; 105
	i32 279, ; 106
	i32 205, ; 107
	i32 117, ; 108
	i32 309, ; 109
	i32 291, ; 110
	i32 78, ; 111
	i32 290, ; 112
	i32 339, ; 113
	i32 114, ; 114
	i32 121, ; 115
	i32 48, ; 116
	i32 174, ; 117
	i32 128, ; 118
	i32 255, ; 119
	i32 226, ; 120
	i32 82, ; 121
	i32 110, ; 122
	i32 75, ; 123
	i32 301, ; 124
	i32 192, ; 125
	i32 217, ; 126
	i32 213, ; 127
	i32 53, ; 128
	i32 281, ; 129
	i32 183, ; 130
	i32 69, ; 131
	i32 280, ; 132
	i32 83, ; 133
	i32 172, ; 134
	i32 324, ; 135
	i32 116, ; 136
	i32 184, ; 137
	i32 156, ; 138
	i32 183, ; 139
	i32 220, ; 140
	i32 167, ; 141
	i32 273, ; 142
	i32 180, ; 143
	i32 247, ; 144
	i32 182, ; 145
	i32 198, ; 146
	i32 32, ; 147
	i32 195, ; 148
	i32 211, ; 149
	i32 122, ; 150
	i32 72, ; 151
	i32 62, ; 152
	i32 161, ; 153
	i32 113, ; 154
	i32 88, ; 155
	i32 209, ; 156
	i32 335, ; 157
	i32 105, ; 158
	i32 18, ; 159
	i32 146, ; 160
	i32 118, ; 161
	i32 58, ; 162
	i32 241, ; 163
	i32 17, ; 164
	i32 52, ; 165
	i32 92, ; 166
	i32 339, ; 167
	i32 332, ; 168
	i32 55, ; 169
	i32 177, ; 170
	i32 338, ; 171
	i32 129, ; 172
	i32 152, ; 173
	i32 41, ; 174
	i32 92, ; 175
	i32 285, ; 176
	i32 197, ; 177
	i32 50, ; 178
	i32 302, ; 179
	i32 162, ; 180
	i32 13, ; 181
	i32 259, ; 182
	i32 223, ; 183
	i32 280, ; 184
	i32 36, ; 185
	i32 67, ; 186
	i32 109, ; 187
	i32 224, ; 188
	i32 99, ; 189
	i32 99, ; 190
	i32 11, ; 191
	i32 11, ; 192
	i32 179, ; 193
	i32 266, ; 194
	i32 25, ; 195
	i32 128, ; 196
	i32 337, ; 197
	i32 76, ; 198
	i32 258, ; 199
	i32 109, ; 200
	i32 284, ; 201
	i32 282, ; 202
	i32 106, ; 203
	i32 2, ; 204
	i32 26, ; 205
	i32 237, ; 206
	i32 157, ; 207
	i32 328, ; 208
	i32 21, ; 209
	i32 331, ; 210
	i32 49, ; 211
	i32 43, ; 212
	i32 126, ; 213
	i32 227, ; 214
	i32 59, ; 215
	i32 119, ; 216
	i32 287, ; 217
	i32 250, ; 218
	i32 236, ; 219
	i32 3, ; 220
	i32 256, ; 221
	i32 276, ; 222
	i32 38, ; 223
	i32 124, ; 224
	i32 190, ; 225
	i32 325, ; 226
	i32 276, ; 227
	i32 176, ; 228
	i32 325, ; 229
	i32 137, ; 230
	i32 149, ; 231
	i32 85, ; 232
	i32 90, ; 233
	i32 260, ; 234
	i32 337, ; 235
	i32 341, ; 236
	i32 216, ; 237
	i32 257, ; 238
	i32 313, ; 239
	i32 232, ; 240
	i32 243, ; 241
	i32 288, ; 242
	i32 201, ; 243
	i32 293, ; 244
	i32 258, ; 245
	i32 133, ; 246
	i32 96, ; 247
	i32 3, ; 248
	i32 321, ; 249
	i32 105, ; 250
	i32 324, ; 251
	i32 33, ; 252
	i32 154, ; 253
	i32 158, ; 254
	i32 155, ; 255
	i32 82, ; 256
	i32 180, ; 257
	i32 252, ; 258
	i32 143, ; 259
	i32 87, ; 260
	i32 19, ; 261
	i32 253, ; 262
	i32 51, ; 263
	i32 222, ; 264
	i32 328, ; 265
	i32 61, ; 266
	i32 54, ; 267
	i32 4, ; 268
	i32 97, ; 269
	i32 221, ; 270
	i32 17, ; 271
	i32 155, ; 272
	i32 84, ; 273
	i32 217, ; 274
	i32 29, ; 275
	i32 45, ; 276
	i32 64, ; 277
	i32 66, ; 278
	i32 319, ; 279
	i32 172, ; 280
	i32 261, ; 281
	i32 1, ; 282
	i32 296, ; 283
	i32 47, ; 284
	i32 24, ; 285
	i32 229, ; 286
	i32 191, ; 287
	i32 177, ; 288
	i32 165, ; 289
	i32 108, ; 290
	i32 12, ; 291
	i32 255, ; 292
	i32 63, ; 293
	i32 27, ; 294
	i32 23, ; 295
	i32 93, ; 296
	i32 168, ; 297
	i32 12, ; 298
	i32 300, ; 299
	i32 214, ; 300
	i32 29, ; 301
	i32 103, ; 302
	i32 14, ; 303
	i32 126, ; 304
	i32 238, ; 305
	i32 270, ; 306
	i32 91, ; 307
	i32 259, ; 308
	i32 9, ; 309
	i32 336, ; 310
	i32 0, ; 311
	i32 86, ; 312
	i32 249, ; 313
	i32 282, ; 314
	i32 323, ; 315
	i32 71, ; 316
	i32 168, ; 317
	i32 1, ; 318
	i32 269, ; 319
	i32 5, ; 320
	i32 323, ; 321
	i32 44, ; 322
	i32 27, ; 323
	i32 190, ; 324
	i32 297, ; 325
	i32 158, ; 326
	i32 272, ; 327
	i32 112, ; 328
	i32 333, ; 329
	i32 121, ; 330
	i32 287, ; 331
	i32 228, ; 332
	i32 206, ; 333
	i32 159, ; 334
	i32 0, ; 335
	i32 131, ; 336
	i32 292, ; 337
	i32 57, ; 338
	i32 187, ; 339
	i32 138, ; 340
	i32 83, ; 341
	i32 30, ; 342
	i32 239, ; 343
	i32 10, ; 344
	i32 289, ; 345
	i32 171, ; 346
	i32 236, ; 347
	i32 150, ; 348
	i32 94, ; 349
	i32 249, ; 350
	i32 60, ; 351
	i32 212, ; 352
	i32 157, ; 353
	i32 308, ; 354
	i32 200, ; 355
	i32 64, ; 356
	i32 88, ; 357
	i32 79, ; 358
	i32 47, ; 359
	i32 210, ; 360
	i32 143, ; 361
	i32 305, ; 362
	i32 185, ; 363
	i32 298, ; 364
	i32 243, ; 365
	i32 74, ; 366
	i32 91, ; 367
	i32 338, ; 368
	i32 295, ; 369
	i32 135, ; 370
	i32 90, ; 371
	i32 281, ; 372
	i32 301, ; 373
	i32 240, ; 374
	i32 303, ; 375
	i32 112, ; 376
	i32 42, ; 377
	i32 159, ; 378
	i32 4, ; 379
	i32 103, ; 380
	i32 194, ; 381
	i32 70, ; 382
	i32 202, ; 383
	i32 60, ; 384
	i32 39, ; 385
	i32 230, ; 386
	i32 153, ; 387
	i32 56, ; 388
	i32 34, ; 389
	i32 199, ; 390
	i32 212, ; 391
	i32 227, ; 392
	i32 21, ; 393
	i32 163, ; 394
	i32 193, ; 395
	i32 293, ; 396
	i32 314, ; 397
	i32 291, ; 398
	i32 286, ; 399
	i32 140, ; 400
	i32 175, ; 401
	i32 317, ; 402
	i32 201, ; 403
	i32 89, ; 404
	i32 147, ; 405
	i32 242, ; 406
	i32 162, ; 407
	i32 271, ; 408
	i32 6, ; 409
	i32 169, ; 410
	i32 31, ; 411
	i32 107, ; 412
	i32 252, ; 413
	i32 218, ; 414
	i32 204, ; 415
	i32 315, ; 416
	i32 286, ; 417
	i32 198, ; 418
	i32 225, ; 419
	i32 279, ; 420
	i32 167, ; 421
	i32 253, ; 422
	i32 140, ; 423
	i32 311, ; 424
	i32 59, ; 425
	i32 144, ; 426
	i32 81, ; 427
	i32 74, ; 428
	i32 195, ; 429
	i32 196, ; 430
	i32 130, ; 431
	i32 25, ; 432
	i32 7, ; 433
	i32 93, ; 434
	i32 283, ; 435
	i32 137, ; 436
	i32 216, ; 437
	i32 219, ; 438
	i32 113, ; 439
	i32 9, ; 440
	i32 218, ; 441
	i32 104, ; 442
	i32 19, ; 443
	i32 205, ; 444
	i32 251, ; 445
	i32 176, ; 446
	i32 265, ; 447
	i32 341, ; 448
	i32 245, ; 449
	i32 33, ; 450
	i32 233, ; 451
	i32 46, ; 452
	i32 316, ; 453
	i32 30, ; 454
	i32 234, ; 455
	i32 57, ; 456
	i32 134, ; 457
	i32 114, ; 458
	i32 288, ; 459
	i32 329, ; 460
	i32 299, ; 461
	i32 55, ; 462
	i32 203, ; 463
	i32 6, ; 464
	i32 77, ; 465
	i32 244, ; 466
	i32 181, ; 467
	i32 111, ; 468
	i32 248, ; 469
	i32 102, ; 470
	i32 303, ; 471
	i32 317, ; 472
	i32 170, ; 473
	i32 115, ; 474
	i32 311, ; 475
	i32 283, ; 476
	i32 238, ; 477
	i32 76, ; 478
	i32 294, ; 479
	i32 85, ; 480
	i32 296, ; 481
	i32 331, ; 482
	i32 231, ; 483
	i32 332, ; 484
	i32 315, ; 485
	i32 192, ; 486
	i32 273, ; 487
	i32 160, ; 488
	i32 2, ; 489
	i32 244, ; 490
	i32 24, ; 491
	i32 224, ; 492
	i32 32, ; 493
	i32 117, ; 494
	i32 37, ; 495
	i32 16, ; 496
	i32 310, ; 497
	i32 52, ; 498
	i32 313, ; 499
	i32 297, ; 500
	i32 20, ; 501
	i32 123, ; 502
	i32 154, ; 503
	i32 251, ; 504
	i32 131, ; 505
	i32 182, ; 506
	i32 305, ; 507
	i32 233, ; 508
	i32 148, ; 509
	i32 220, ; 510
	i32 120, ; 511
	i32 28, ; 512
	i32 132, ; 513
	i32 100, ; 514
	i32 134, ; 515
	i32 271, ; 516
	i32 153, ; 517
	i32 97, ; 518
	i32 125, ; 519
	i32 221, ; 520
	i32 69, ; 521
	i32 72, ; 522
	i32 326, ; 523
	i32 256, ; 524
	i32 274, ; 525
	i32 307, ; 526
	i32 136, ; 527
	i32 124, ; 528
	i32 71, ; 529
	i32 111, ; 530
	i32 266, ; 531
	i32 188, ; 532
	i32 152, ; 533
	i32 318, ; 534
	i32 334, ; 535
	i32 294, ; 536
	i32 118, ; 537
	i32 242, ; 538
	i32 173, ; 539
	i32 335, ; 540
	i32 302, ; 541
	i32 127, ; 542
	i32 133, ; 543
	i32 189, ; 544
	i32 77, ; 545
	i32 46, ; 546
	i32 245, ; 547
	i32 73, ; 548
	i32 63, ; 549
	i32 191, ; 550
	i32 98, ; 551
	i32 84, ; 552
	i32 319, ; 553
	i32 43, ; 554
	i32 61, ; 555
	i32 204, ; 556
	i32 272, ; 557
	i32 184, ; 558
	i32 37, ; 559
	i32 40, ; 560
	i32 235, ; 561
	i32 300, ; 562
	i32 160, ; 563
	i32 98, ; 564
	i32 240, ; 565
	i32 189, ; 566
	i32 179, ; 567
	i32 193, ; 568
	i32 135, ; 569
	i32 20, ; 570
	i32 65, ; 571
	i32 306, ; 572
	i32 125, ; 573
	i32 75, ; 574
	i32 264, ; 575
	i32 174, ; 576
	i32 164, ; 577
	i32 156, ; 578
	i32 306, ; 579
	i32 5, ; 580
	i32 314, ; 581
	i32 49, ; 582
	i32 278, ; 583
	i32 307, ; 584
	i32 144, ; 585
	i32 187, ; 586
	i32 139, ; 587
	i32 100, ; 588
	i32 209, ; 589
	i32 123, ; 590
	i32 120, ; 591
	i32 142, ; 592
	i32 39, ; 593
	i32 68, ; 594
	i32 41, ; 595
	i32 164, ; 596
	i32 73, ; 597
	i32 215, ; 598
	i32 320, ; 599
	i32 165, ; 600
	i32 199, ; 601
	i32 127, ; 602
	i32 250, ; 603
	i32 299, ; 604
	i32 68, ; 605
	i32 169, ; 606
	i32 197, ; 607
	i32 263, ; 608
	i32 237, ; 609
	i32 214, ; 610
	i32 270, ; 611
	i32 151, ; 612
	i32 45, ; 613
	i32 108, ; 614
	i32 48, ; 615
	i32 96, ; 616
	i32 31, ; 617
	i32 23, ; 618
	i32 166, ; 619
	i32 22, ; 620
	i32 138, ; 621
	i32 78, ; 622
	i32 327, ; 623
	i32 54, ; 624
	i32 263, ; 625
	i32 268, ; 626
	i32 10, ; 627
	i32 226, ; 628
	i32 340, ; 629
	i32 267, ; 630
	i32 254, ; 631
	i32 186, ; 632
	i32 16, ; 633
	i32 175, ; 634
	i32 178, ; 635
	i32 334, ; 636
	i32 139, ; 637
	i32 207, ; 638
	i32 13, ; 639
	i32 15, ; 640
	i32 122, ; 641
	i32 196, ; 642
	i32 87, ; 643
	i32 149, ; 644
	i32 22, ; 645
	i32 34, ; 646
	i32 79, ; 647
	i32 312, ; 648
	i32 292, ; 649
	i32 327, ; 650
	i32 147, ; 651
	i32 80, ; 652
	i32 310, ; 653
	i32 173, ; 654
	i32 219, ; 655
	i32 322, ; 656
	i32 42, ; 657
	i32 26, ; 658
	i32 333, ; 659
	i32 265, ; 660
	i32 262, ; 661
	i32 107, ; 662
	i32 110, ; 663
	i32 206, ; 664
	i32 7, ; 665
	i32 178, ; 666
	i32 295, ; 667
	i32 44, ; 668
	i32 161, ; 669
	i32 148, ; 670
	i32 321, ; 671
	i32 231, ; 672
	i32 267, ; 673
	i32 38, ; 674
	i32 15, ; 675
	i32 146, ; 676
	i32 8, ; 677
	i32 248, ; 678
	i32 269, ; 679
	i32 130, ; 680
	i32 316, ; 681
	i32 285, ; 682
	i32 94 ; 683
], align 16

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 16

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ df9aaf29a52042a4fbf800daf2f3a38964b9e958"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}