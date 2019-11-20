
let histogram (src : string) : int list =
    let alphabet = ['a'..'z']@[' ']

    // Switch space character count to the last element

    // let rec count_list_gen (lst : char list) (prev_char : char) : int list =
    let folder acc char =
        acc @ [(List.length (List.filter (fun elem -> char = elem) (Seq.toList (src.ToLower()))))]

    List.fold folder [] alphabet

// printfn "%A" (histogram "-..Hello There-.,-.,")
// printfn "%A" (histogram " ")

let histogram2 (src : string) : int list =
    let alphabet = ['a'..'z']@[' ']

    // Switch space character count to the last element

    // let rec count_list_gen (lst : char list) (prev_char : char) : int list =
    let folder char acc =
        (List.length (List.filter (fun elem -> char = elem) (Seq.toList (src.ToLower())))) :: acc

    List.foldBack folder alphabet []

let histogram3 (src : string) : int list =
    let alphabet = ['a'..'z']@[' ']
    let lowerText = (Seq.toList (src.ToLower()))

    let countFun (alphChar : char) : int =
        let folder (acc : int) (srcChar : char) : int =
            match alphChar with
            | x when x = srcChar -> acc + 1
            | _               -> acc
        List.fold folder 0 lowerText

    List.map countFun alphabet

printfn "%A" (histogram3 "-..Hello There-.,-.,")
printfn "%A" (histogram3 " ")

let lipsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In sagittis risus nec erat maximus, a tincidunt urna tempus. Praesent vulputate massa ut arcu finibus consectetur. Sed maximus justo pharetra enim faucibus, vel bibendum justo pulvinar. Integer ac velit at est egestas volutpat at vel enim. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Suspendisse sit amet magna quis elit porta laoreet quis at mi. Etiam ac ante in purus faucibus iaculis nec a nibh. Donec mauris augue, volutpat id libero eu, malesuada pretium libero. Fusce congue consectetur eros id maximus. Mauris vel tellus aliquam erat facilisis ornare sed nec sem. Pellentesque quis ante sed odio ultricies hendrerit eget eu urna.

Nunc id mauris pulvinar, hendrerit purus non, finibus est. Praesent sit amet congue magna. Mauris quis massa nunc. Vestibulum condimentum tellus justo, eu tincidunt mauris vulputate eget. Pellentesque sit amet elit turpis. Sed nec purus ultrices, aliquam magna vitae, pulvinar erat. Curabitur convallis sem ac porttitor lacinia. Pellentesque quam nisl, tincidunt sit amet feugiat imperdiet, iaculis non justo. Aenean sed vestibulum justo, non sagittis leo. Aliquam aliquam purus sed sagittis rutrum. Duis eget ex commodo, mattis felis et, maximus eros. Vivamus tincidunt sapien molestie congue malesuada. Nulla facilisi. Maecenas cursus nibh id maximus facilisis.

Nam quis tempus dolor. Sed auctor malesuada justo, eget tempor augue vehicula eu. Phasellus dignissim velit nunc, id vehicula diam consectetur et. Aliquam erat volutpat. Aliquam in odio ac magna ultrices pellentesque. Integer iaculis euismod ipsum et semper. Sed tincidunt sodales odio id cursus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec aliquam nisl, vel cursus leo. Aliquam quis massa ante. Vestibulum magna dui, cursus id magna sit amet, efficitur dignissim risus.

Donec aliquam justo sed ultrices vehicula. Nunc mollis velit mauris, ac mattis diam posuere eget. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis vel dui sed tellus tincidunt semper ac sed magna. Etiam faucibus efficitur facilisis. Donec in tempor lacus, quis dapibus lorem. Sed auctor leo vel gravida eleifend.

Nullam sem ex, ultrices at scelerisque at, lacinia sit amet lectus. Pellentesque neque eros, congue non vehicula vestibulum, dictum et quam. Sed porta, erat quis maximus gravida, mi lacus viverra leo, in sollicitudin enim nulla ac lectus. Sed arcu magna, tincidunt sed mi et, vestibulum mattis dolor. Phasellus lobortis varius turpis id mattis. Nam id ligula ac purus ultricies finibus. Sed tempor placerat vestibulum. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Cras vitae elit sit amet justo molestie imperdiet. Nulla ultrices purus eu cursus malesuada. Vivamus sed consequat felis.

Donec fringilla velit quis placerat semper. Aenean vel urna eleifend, tincidunt erat a, elementum purus. Suspendisse eu mi ullamcorper, varius ex et, convallis velit. Mauris sit amet ipsum massa. Aenean luctus nunc cursus, elementum ligula a, pulvinar enim. Vivamus sagittis augue venenatis, eleifend libero id, gravida velit. Integer porttitor sodales pretium. Fusce congue nisl sit amet suscipit lobortis. In placerat euismod nunc accumsan placerat. Integer rhoncus ullamcorper felis at dapibus. Cras condimentum, purus vitae sollicitudin suscipit, ex libero rutrum ex, nec laoreet metus tortor ut justo.

In sit amet purus est. Phasellus sodales quam non mi commodo, id consequat justo iaculis. Pellentesque eget sagittis ipsum, et viverra lorem. Proin pretium ante porttitor urna maximus auctor sit amet et ipsum. Morbi ut lacus in purus iaculis consequat eget vitae augue. Sed eu arcu laoreet, maximus augue eget, euismod justo. In nunc nunc, placerat id felis malesuada, tincidunt tincidunt est. Vestibulum varius consectetur orci, a imperdiet est sodales a. Proin faucibus lectus augue, a ultricies erat pellentesque sit amet. Morbi diam tellus, maximus non ex in, pharetra rhoncus ex. Suspendisse risus mi, ornare nec est ac, volutpat mattis mauris. Quisque quis nisi nec tortor efficitur faucibus ac vel enim. Pellentesque a interdum mi, at venenatis nisi.

Nullam viverra erat vel odio mattis, eu interdum est mollis. Vivamus ullamcorper imperdiet dolor, non bibendum tellus dictum sit amet. Vestibulum nec dapibus eros, et pulvinar augue. Suspendisse tempus lectus lectus, pharetra molestie tortor pellentesque ac. Quisque euismod nunc sit amet urna venenatis, sed hendrerit enim faucibus. Curabitur elementum sollicitudin sodales. Quisque bibendum ex id felis rutrum venenatis. Donec luctus diam nec magna maximus accumsan. Quisque luctus vulputate arcu. Nunc vitae sem gravida, vestibulum orci pretium, fermentum nisl. Nulla lacinia, velit in tristique feugiat, sem leo interdum arcu, sed lacinia nisl metus a augue. Nam interdum elementum magna, a varius orci maximus eu. Phasellus imperdiet molestie est at iaculis.

Phasellus tincidunt sem venenatis mi congue varius. Integer at est eget ante congue dictum in ut lacus. Pellentesque quis posuere orci, auctor laoreet odio. Cras nisi ante, ultrices in tellus eget, elementum porta est. Pellentesque varius orci eget porta semper. Suspendisse molestie massa ut urna commodo bibendum. Vivamus at tortor tincidunt, gravida dolor a, imperdiet quam. Sed nunc risus, sodales volutpat suscipit et, finibus lacinia magna. Etiam a ex sit amet tortor malesuada blandit. Proin a neque erat. Morbi porta, mauris a mollis eleifend, justo libero interdum magna, id ultricies quam elit vel justo. Phasellus sed luctus arcu. Fusce tincidunt dui vel leo aliquam semper. Maecenas convallis turpis nec tortor euismod, a eleifend odio mattis.

Duis lobortis, mauris id consequat ornare, lacus neque ornare nisi, vestibulum ornare lorem ante eu quam. Donec eget elit convallis, scelerisque augue in, feugiat massa. Vestibulum semper sapien elit, non volutpat enim commodo id. Vivamus blandit eros placerat lacus posuere, sed sagittis nisi tincidunt. Sed a urna vel nisi tincidunt imperdiet nec a nibh. In nec egestas nulla. Suspendisse sollicitudin lorem quis dolor molestie imperdiet. In ac faucibus nisi, vitae varius eros. Ut maximus lectus eget nisi porttitor luctus. Phasellus eget ullamcorper odio. Morbi ante tortor, elementum id lobortis sed, sodales at massa. Nunc ornare velit orci, et suscipit nisi sollicitudin non. Sed vulputate urna risus, vitae scelerisque nunc eleifend ut. Cras varius nulla a justo malesuada, nec malesuada risus tincidunt. Integer vel volutpat libero.

Proin ullamcorper egestas mauris, eget mollis sem blandit non. Ut vehicula neque sit amet tincidunt eleifend. Maecenas facilisis fermentum sem, ut rutrum odio maximus molestie. Curabitur congue dictum aliquet. Etiam condimentum leo vitae mi imperdiet consectetur. Proin ac nulla sit amet neque condimentum malesuada. Vestibulum pharetra quis ex quis varius. Nulla vitae ipsum luctus, bibendum augue et, molestie arcu. Nulla nulla diam, rutrum sed laoreet ac, fringilla in risus.

Vivamus ex mi, feugiat et pellentesque in, faucibus quis metus. Integer pharetra, libero et condimentum vulputate, nisi tellus vulputate libero, vitae rhoncus elit neque eu erat. Vestibulum non ante neque. Fusce tincidunt eu tellus id convallis. Ut quis turpis dui. Morbi odio augue, vehicula sit amet ligula in, hendrerit iaculis enim. Suspendisse ac tortor fringilla, tristique mi sed, scelerisque odio. Vestibulum in aliquet leo. Nunc elementum metus sed turpis pretium ultrices. Nam sit amet lacus sed diam volutpat rhoncus nec et nibh. Nam sed elementum diam.

Donec ac scelerisque nibh. Nunc libero quam, pulvinar a pulvinar at, maximus id lectus. Mauris aliquet turpis ac mauris lacinia, at tempus mi placerat. Nulla faucibus, odio vitae dapibus condimentum, velit justo viverra dui, vitae vestibulum velit diam a risus. Vivamus rutrum odio quis sem faucibus, sit amet auctor tortor mattis. Duis in nisl urna. Mauris bibendum pharetra maximus. Etiam nisl ligula, interdum vel nulla eu, scelerisque faucibus nibh. Phasellus id dignissim felis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec nisi nisl, bibendum ut sagittis in, auctor malesuada leo. Nulla facilisi. Proin posuere sed est vel suscipit. Vivamus nec eros vel ante interdum luctus a ut purus. In in semper metus.

Curabitur tristique eget orci ut varius. Aliquam feugiat leo at sollicitudin cursus. Etiam tempus orci ut nulla iaculis, sit amet sollicitudin turpis tempus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris at consectetur quam. Fusce interdum tincidunt lectus in molestie. In non sapien massa.

Duis et elit vitae lacus finibus egestas ut et ante. Nunc vestibulum porttitor dolor, in porta mauris ultrices sit amet. Morbi mollis tortor ac facilisis scelerisque. Donec ullamcorper nibh nisi, nec euismod risus auctor quis. Suspendisse suscipit aliquet ligula quis blandit. Sed augue enim, tincidunt et ipsum vitae, imperdiet iaculis ante. Integer lacinia massa non dui dapibus, sed condimentum eros facilisis. Maecenas egestas, ligula nec feugiat ultricies, urna tortor venenatis dolor, vel facilisis nibh tellus ac turpis. Donec eget mauris quis orci varius elementum ac tempus massa. Duis vel dolor sem. Mauris non leo vitae nisi maximus fringilla. Cras fermentum ultrices maximus. Praesent elementum posuere ipsum, quis ullamcorper eros egestas sit amet.

Mauris non risus in eros tempor elementum sit amet facilisis ipsum. Duis laoreet, risus non aliquam tempor, velit leo pharetra metus, in vehicula leo urna quis tortor. Donec suscipit consectetur nibh, eget pretium orci gravida a. Aliquam pharetra erat ac nisi varius congue. Sed eget risus pharetra justo viverra mollis. Morbi ac eleifend mi, non malesuada purus. Nulla sed ex pulvinar, posuere lacus eu, ultricies neque. Nunc scelerisque ligula at lectus gravida, vitae tincidunt arcu varius. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Praesent sem tellus, aliquet ac ipsum vel, faucibus luctus elit. Sed eget ante rutrum, bibendum massa ac, tempus lorem. Proin pretium urna sit amet commodo facilisis. Proin euismod eros urna, eget molestie nulla posuere at.

Morbi pretium mi est, eget pharetra nisl varius dapibus. Curabitur in risus id erat dictum hendrerit quis vitae nibh. Aliquam lacinia nisl vitae massa vulputate tempor. Integer faucibus lacus sit amet tortor bibendum maximus. Phasellus sagittis dignissim lacus, nec lacinia velit ultricies congue. Nullam egestas, orci quis tincidunt faucibus, risus ex eleifend felis, ut tempus neque turpis ac urna. Nunc elementum diam in eros malesuada, faucibus vestibulum nulla convallis. Morbi interdum, purus a venenatis placerat, lacus eros sagittis tortor, nec aliquet mauris nisl ac lacus. Vivamus sit amet ante quis ex tempus sollicitudin sed non tortor. Sed egestas, massa quis rhoncus placerat, libero nisi tristique diam, a sagittis lectus dolor et dolor. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc auctor elementum finibus.

In posuere orci a vehicula ultricies. Sed vel risus eros. Aenean in diam neque. Etiam vel ex mattis mi condimentum imperdiet id at tellus. Duis sit amet odio consectetur, facilisis velit sed, rutrum odio. Cras elementum molestie ipsum, vitae consequat ex iaculis ac. Morbi nec odio id ipsum hendrerit interdum vitae vel erat. Etiam nulla nunc, consequat nec egestas et, feugiat vitae turpis.

Cras luctus efficitur porttitor. Phasellus euismod mollis nisl. In ac lacus est. Donec aliquet at urna at tempus. Suspendisse potenti. Mauris id commodo orci. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin nec interdum lacus, id ultrices nulla. Cras in hendrerit lacus, vel blandit risus.

Mauris elementum rhoncus diam in hendrerit. Integer accumsan porta diam venenatis pretium. Suspendisse potenti. Mauris vitae orci eu sem ullamcorper consequat. Donec varius, turpis in vulputate pretium, velit mauris dignissim tortor, finibus scelerisque diam tortor ut nibh. Nam lacinia justo at mi consequat dictum. Nullam sit amet purus euismod nisl facilisis auctor. In viverra finibus dictum. Nunc maximus porttitor sem nec pulvinar.

Praesent fermentum risus purus, rutrum interdum enim finibus eget. Fusce pulvinar orci sem, ac tristique massa elementum ac. Integer ultricies turpis a felis dapibus egestas. Donec sed metus in turpis egestas hendrerit. Nullam ullamcorper massa erat, ut maximus sapien tristique eget. Sed tincidunt posuere urna, vitae laoreet libero suscipit sit amet. Aliquam blandit velit sit amet ante feugiat consectetur. Curabitur vestibulum pharetra velit quis tincidunt. Cras maximus, augue commodo lobortis consectetur, quam mauris suscipit diam, consequat rutrum turpis eros at nunc. Sed mollis, ante in ullamcorper fringilla, sapien lectus consectetur lacus, iaculis tempus neque mauris id metus. Sed non ornare libero, vitae porta augue. Vivamus at nunc at ex aliquet auctor et non arcu.

Nullam feugiat scelerisque elit sed semper. Sed mattis volutpat nibh, non fringilla nisl feugiat maximus. Mauris eget blandit eros. Mauris facilisis varius porta. Donec massa purus, elementum non venenatis et, fringilla ut ipsum. Donec ultrices efficitur tempus. Quisque libero est, scelerisque at dolor sit amet, tristique auctor sem. Sed sodales libero vitae urna ultricies, a fringilla velit tincidunt. Cras aliquet diam vitae blandit semper. Praesent at commodo nibh, a imperdiet nisi.

Aliquam quis volutpat dolor, et convallis turpis. Aenean suscipit felis in nisi bibendum vehicula. Cras porta eros sed nisi pellentesque facilisis. Suspendisse in nisl nisl. Praesent fermentum pulvinar erat vitae congue. Nam sem ante, efficitur at tincidunt congue, sodales sit amet nisl. Pellentesque eu sapien augue. In sagittis ullamcorper nulla. Aenean vel turpis urna. Vivamus feugiat, ipsum quis consequat faucibus, diam metus suscipit felis, at interdum est arcu eu felis. Curabitur scelerisque at lacus eget ultrices. Nulla facilisi. Integer quis aliquam turpis.

Quisque id tellus commodo, viverra dolor fringilla, elementum nisi. Mauris varius diam vitae gravida rhoncus. Donec at mauris quis purus mollis mattis. Aliquam non augue quis libero aliquam lacinia imperdiet lacinia purus. Donec ullamcorper risus ut consequat interdum. Suspendisse hendrerit fermentum bibendum. Nam iaculis velit id nulla volutpat, id sollicitudin odio pulvinar. Morbi quis ultrices justo, ut aliquam augue.

Fusce accumsan malesuada enim et convallis. Nulla aliquet dapibus fringilla. Fusce ante odio, tempus non vehicula vel, euismod ut arcu. Morbi molestie tellus a arcu pharetra, eget hendrerit lorem sollicitudin. Nunc faucibus, quam a mattis ullamcorper, nibh nibh lobortis sapien, ut pharetra enim dui non nisi. Etiam molestie nisi a pretium lobortis. Pellentesque venenatis dictum tortor in facilisis. Etiam mauris purus, posuere eget bibendum ut, blandit non mi. Pellentesque venenatis feugiat tortor, hendrerit tempor leo tincidunt eget. Ut feugiat, urna a placerat iaculis, justo leo imperdiet dui, eleifend gravida risus ipsum a metus. Curabitur malesuada dictum purus. Nulla at vestibulum erat, sed ultricies velit.

Suspendisse in dignissim nisi. Interdum et malesuada fames ac ante ipsum primis in faucibus. Integer malesuada neque in vehicula eleifend. Vestibulum vitae ornare neque. Duis vulputate convallis eros. Praesent eget consectetur metus, commodo dapibus lectus. Sed porta molestie justo, et dictum felis fermentum in. Vivamus quis ultricies arcu. Nam suscipit, arcu rutrum pharetra convallis, tortor massa placerat urna, vitae ultrices nisl mauris ut elit. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec sollicitudin augue varius laoreet lobortis. Fusce quis justo fermentum, sollicitudin tellus sit amet, consequat nunc. Phasellus lobortis lacinia ultricies. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas et justo venenatis, ultricies magna a, dignissim ipsum. Sed at malesuada augue, quis placerat ipsum.

Integer vel magna convallis, interdum purus quis, consectetur lacus. Aliquam iaculis dapibus risus, mattis tristique arcu condimentum non. Morbi rhoncus consequat lorem, at interdum massa commodo et. Nunc posuere ligula in odio tristique, mattis pretium ligula vestibulum. Nunc a tincidunt nunc. Nulla rhoncus efficitur porttitor. Quisque in erat at turpis gravida pharetra a ac orci. Pellentesque sit amet metus condimentum, sodales augue eget, porttitor ligula. Donec eros felis, posuere id vehicula quis, auctor vel orci. Aenean condimentum bibendum venenatis.

Nam ligula lorem, malesuada eget dui a, finibus placerat nisi. In non mauris et tortor imperdiet scelerisque. Sed elementum luctus enim pellentesque ultricies. Suspendisse efficitur tellus at felis consectetur, ac dapibus mauris tempor. Donec tristique est eget lacus mollis euismod. Donec eleifend ac nibh dictum tincidunt. In quis nisi lectus. Suspendisse sed ipsum est. Sed id elit ac libero mattis malesuada nec et mi.

Morbi pretium purus erat, accumsan lobortis lectus interdum vitae. Vivamus tempor ultrices arcu, in pulvinar velit mattis sit amet. Nullam sodales luctus laoreet. Mauris tempor neque at sagittis cursus. Suspendisse vel justo semper, suscipit enim non, scelerisque lorem. Praesent interdum venenatis libero in aliquet. Suspendisse accumsan nibh ac accumsan iaculis. Vestibulum non tincidunt tellus. Vivamus a nulla nisi. Duis lectus ligula, venenatis sit amet blandit at, dignissim et risus. Suspendisse quis massa faucibus, ultrices velit ut, volutpat velit. Proin suscipit metus nisi, non cursus ante sollicitudin id. Nunc dictum, nulla placerat maximus porttitor, dolor mi vehicula lectus, ac gravida erat mauris in massa. Nam at metus vel ipsum efficitur pharetra eu at purus. Ut eros erat, efficitur quis massa in, varius vehicula libero.

Quisque eget justo dignissim, auctor lacus nec, faucibus neque. Integer hendrerit urna in felis consectetur molestie. Vivamus varius, libero vel varius iaculis, libero tellus pellentesque dui, id congue nisi odio ut augue. Aliquam tempor faucibus lectus eu tempor. Suspendisse massa eros, rhoncus nec consequat id, blandit at turpis. Duis velit urna, sagittis vel consequat non, faucibus eget ligula. Donec dictum, tellus ac accumsan fringilla, nulla erat posuere eros, ut eleifend turpis augue sit amet quam. Ut feugiat augue sed facilisis iaculis. Aliquam facilisis malesuada est. Fusce tempus, magna eget sodales tincidunt, nulla sapien vulputate ligula, nec cursus mi dui ac nulla. Fusce vehicula est sit amet lacus venenatis egestas. Fusce dictum purus vel sem eleifend eleifend. Donec hendrerit in lectus at aliquet. Proin luctus dignissim egestas.

Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent egestas mauris eu magna aliquam, quis vehicula nulla consequat. Vestibulum feugiat lectus in accumsan scelerisque. Nunc consectetur quam ut justo vulputate, vel eleifend ante facilisis. Aliquam ornare sem felis, vel feugiat velit semper quis. Sed dignissim risus quam. Integer quis erat enim. Donec sodales mauris eget arcu consectetur sagittis et et lectus. Fusce sit amet vehicula libero. Phasellus tincidunt volutpat varius.

Nullam consequat nec lectus vitae dictum. Praesent diam odio, laoreet nec luctus at, porttitor nec ligula. Nulla facilisi. Nunc finibus elit in interdum semper. Sed fermentum consectetur luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Integer rhoncus tortor ut felis tempor mollis. Maecenas nec lectus suscipit, bibendum lacus eget, suscipit lorem.

Nulla turpis libero, porttitor quis euismod nec, scelerisque sit amet purus. Curabitur nec dolor luctus, pharetra justo vitae, tincidunt nisi. Donec vitae est sed dolor tempor suscipit. Sed accumsan massa velit, sed tempor mauris hendrerit et. Sed interdum porttitor metus, eget ornare lacus blandit ac. Phasellus erat purus, ultrices lacinia semper eget, porta vitae mauris. Morbi tempus nisi nec tortor sodales vulputate. Mauris ut lacus vestibulum, auctor ipsum ac, luctus ex. Nunc ac arcu interdum, malesuada felis in, fermentum est. Nulla pretium odio vel mauris elementum, at aliquet tellus malesuada. Mauris dolor mauris, scelerisque at elit ultricies, dictum commodo ligula. Aenean dapibus malesuada mi non sodales.

Quisque orci ante, facilisis et libero vel, congue luctus metus. Maecenas vitae vestibulum augue. Maecenas faucibus interdum ipsum, non accumsan dui pellentesque vitae. Vivamus porttitor magna libero, in eleifend augue mollis maximus. Duis sit amet risus a diam scelerisque pulvinar. Donec eleifend risus ut scelerisque condimentum. Ut tristique, elit quis semper hendrerit, nisl augue auctor ex, quis pulvinar lacus justo at risus. Cras molestie gravida ultrices. Etiam orci erat, convallis at pulvinar et, ullamcorper quis dui. In hac habitasse platea dictumst. In scelerisque bibendum metus, sit amet bibendum mauris vehicula non.

Ut eros leo, sodales eu sagittis ut, porttitor sed sem. Maecenas a cursus mi, id bibendum sapien. In a suscipit mi, eget accumsan felis. Nulla id est sed urna dignissim pellentesque. Mauris et porttitor augue. Nam ac fermentum orci. Nulla sit amet sem purus. Nullam vitae nunc convallis, condimentum nisi vel, varius nulla. Aenean nec finibus nulla. Suspendisse egestas, arcu non consequat molestie, tellus sem molestie massa, dictum ultricies dui ipsum id urna. Quisque rutrum semper rutrum.

Etiam sollicitudin, ante vitae tincidunt vehicula, ante lectus convallis sapien, non euismod metus quam efficitur tellus. Aliquam id lobortis orci, quis mollis neque. Proin vel consequat massa, eu venenatis tortor. Proin ac condimentum eros, id tristique nunc. Quisque auctor aliquam fringilla. Duis porttitor lobortis nulla, vel posuere tortor lacinia vitae. Suspendisse in dolor bibendum, placerat ipsum non, molestie magna. Nullam sit amet elit elit. Suspendisse euismod tristique libero sit amet tincidunt. Aliquam et enim nec tortor fermentum tempor bibendum et leo. In blandit vel nisl eget commodo. Vestibulum dapibus egestas nisi, convallis cursus sapien vehicula in. Praesent eget sapien at arcu luctus tristique a id ligula. Aliquam euismod vel mauris sit amet rutrum.

Quisque aliquam eget diam vel tincidunt. Nullam id lectus arcu. Suspendisse dictum, felis id mattis viverra, augue nunc tempus lorem, at ullamcorper nunc urna imperdiet odio. Nulla et velit id sapien malesuada cursus. Maecenas id metus sed ipsum gravida vulputate quis sit amet tellus. Cras a condimentum augue, sit amet molestie urna. Nulla in orci nisi. Aliquam in diam sed ante viverra tristique. Nulla tempus odio sed est ultricies egestas. Cras fringilla justo non libero pulvinar pharetra. Nam a sodales ligula. Sed sodales erat non leo vehicula congue. Ut porta justo at urna dapibus fringilla. Interdum et malesuada fames ac ante ipsum primis in faucibus.

Nulla ex libero, rhoncus a interdum nec, commodo id arcu. Morbi porttitor tristique neque eu pulvinar. Nullam lacinia quam sit amet tristique convallis. Nunc nec gravida mi. Nulla lacinia tincidunt pretium. Sed congue lobortis urna, quis auctor ante consequat et. Duis vulputate posuere quam, et sollicitudin eros finibus non. Aenean sollicitudin enim suscipit iaculis imperdiet. Morbi a placerat neque, et egestas mi. Maecenas eget ligula egestas, tincidunt turpis ut, interdum dolor. Vestibulum ante quam, dignissim eu interdum vel, vulputate in arcu. Suspendisse porta, libero nec pellentesque porta, orci ex tincidunt magna, auctor ultrices mi erat sit amet velit. Vestibulum maximus sem at nulla cursus, vel aliquet magna finibus. Nunc tristique, ipsum in ultrices mollis, erat sem congue arcu, vitae lobortis felis libero non nunc. Vivamus viverra porttitor convallis. Nunc ut enim hendrerit, hendrerit risus non, elementum augue.

Pellentesque non mi id nisi sodales vulputate. Nam vel nisl dolor. Quisque lacus est, congue eu metus vel, eleifend tincidunt odio. Nulla sapien turpis, molestie rhoncus elementum ut, posuere vel velit. Phasellus gravida neque non ullamcorper scelerisque. In arcu nisl, elementum vel lobortis quis, cursus sit amet purus. Donec cursus lacus nec tincidunt maximus. In arcu erat, maximus ac sodales sit amet, laoreet quis odio. Praesent ac varius magna, at mollis elit. In tempus lobortis tellus, eu lobortis metus efficitur non. Curabitur ut lorem at justo placerat luctus. Aliquam eu est et felis malesuada consectetur. Phasellus euismod nunc nisl, eu tristique tellus auctor ac. Maecenas iaculis efficitur diam, eget aliquam ex sollicitudin laoreet. Aenean porta volutpat ipsum vel posuere. Vestibulum sed pellentesque felis, et pretium sapien.

Integer lobortis augue eu elit mattis feugiat. Suspendisse mi purus, dapibus ut enim eget, condimentum volutpat ligula. Quisque posuere eros id sapien vehicula, sit amet lacinia leo blandit. Aenean eu dapibus lacus, a dignissim urna. Aliquam at convallis arcu, nec facilisis lectus. Vivamus quis mauris ut dolor consequat sollicitudin. Nam ornare sagittis facilisis. Aliquam non mauris nisl. Morbi dictum purus nibh, id pulvinar elit auctor in. Aenean at ex risus.

Fusce in ex eget turpis lobortis interdum eu id nibh. Vivamus quam nisl, faucibus eget justo in, efficitur pellentesque urna. Quisque nec tincidunt felis. Sed quis quam eget odio commodo viverra. Morbi mattis tincidunt metus ut convallis. Nulla nulla dolor, vestibulum pretium elit in, molestie dictum neque. Etiam dapibus euismod diam ut consequat. Nullam gravida maximus tincidunt. Nulla posuere tellus nec est sodales, id lacinia ex maximus. Phasellus elementum nisl et fermentum auctor. Mauris condimentum laoreet aliquam. Duis mollis mi ac ante ornare, ut vestibulum turpis pulvinar.

Pellentesque vel odio ut justo euismod imperdiet feugiat eu massa. Duis purus quam, malesuada quis lacinia quis, suscipit ac nisl. Aenean in egestas turpis, ac condimentum metus. Curabitur ornare leo quis purus posuere feugiat. Suspendisse potenti. In euismod tincidunt hendrerit. Vivamus tempor justo quis erat vestibulum feugiat. Nam viverra sapien ac egestas porta. Praesent non consectetur neque. Maecenas fermentum nunc fermentum porta sagittis.

In hac habitasse platea dictumst. Donec nunc leo, gravida vel libero sed, ullamcorper mattis lacus. Fusce a velit ut augue scelerisque accumsan eget id sem. Sed at urna urna. Pellentesque condimentum vel elit id imperdiet. Mauris in lacus elit. Nam a leo nec dui rhoncus auctor at at metus. Vestibulum eu diam fermentum, pulvinar turpis ut, pellentesque ex. Sed odio ex, cursus et erat at, facilisis tempor est.

Nullam malesuada ac lorem at sollicitudin. Aenean faucibus vestibulum diam ut tincidunt. Duis et hendrerit diam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam a porta elit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Maecenas vehicula risus dolor, ac consectetur urna dapibus sit amet. Sed mattis elit nec erat laoreet, vitae commodo neque finibus. Donec condimentum elit sit amet enim molestie dictum. Phasellus non efficitur diam. Aenean tincidunt, quam quis pellentesque mollis, eros turpis maximus turpis, non dictum dui magna ut libero.

Phasellus ac porta ante. Aenean eget neque et neque vestibulum mollis. Maecenas cursus sodales leo. Nunc ut euismod dui. Suspendisse ac est non erat tempus fermentum ac ac dolor. Sed sit amet fringilla metus, quis viverra ipsum. Phasellus fermentum quis diam non iaculis. Fusce tortor lorem, elementum sed feugiat eu, tristique ac odio. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. In et maximus ante, ut tincidunt risus. Cras id nibh libero. Morbi at purus bibendum, vehicula lorem id, egestas lectus. Vivamus ut leo at dolor dictum accumsan.

Sed vehicula dolor ex, sed gravida dolor mattis at. Pellentesque ut orci euismod, vulputate quam vel, tristique sem. Ut vitae maximus elit. Vivamus vel pulvinar ipsum. Duis urna neque, pellentesque non efficitur sit amet, pulvinar vitae urna. Duis mattis orci vel quam viverra placerat. Mauris cursus molestie augue sed molestie. Phasellus egestas accumsan nulla eu rutrum. Fusce tempor, odio id finibus porta, urna massa interdum turpis, ut fermentum orci libero eget urna. Vivamus non rutrum orci.

Curabitur ipsum quam, rutrum nec feugiat vel, hendrerit sed urna. Etiam scelerisque dignissim vulputate. Curabitur malesuada, turpis id placerat elementum, diam ipsum ullamcorper ex, id consequat diam neque quis mauris. In in tortor rutrum, porttitor sem at, aliquam est. Nulla sit amet ligula mauris. Integer tortor justo, molestie sed gravida eget, dignissim quis augue. Mauris volutpat ante ut nisl mattis fermentum.

Nunc sed suscipit sem. Suspendisse viverra eget eros aliquam consectetur. Donec a faucibus ipsum. Sed interdum, enim auctor mollis aliquet, libero odio iaculis tortor, ut tempus tortor sapien eu eros. Nunc elementum nisl eget ante rhoncus ultricies. Pellentesque vestibulum porttitor mattis. Donec dolor tellus, consectetur sit amet tincidunt non, rhoncus sed metus. Curabitur id lectus felis. Praesent rutrum diam at congue imperdiet. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.

Aenean dapibus ante eget sodales convallis. Nunc turpis elit, scelerisque ut nulla a, vulputate interdum purus. Aliquam lobortis mauris at ex vestibulum consectetur. Sed consequat velit sed libero venenatis venenatis. Suspendisse neque lorem, semper vitae felis maximus, mattis faucibus neque. Nullam ultricies nisi dolor, nec placerat justo facilisis at. Suspendisse lacinia blandit eros, et egestas mauris aliquam commodo. Proin accumsan, lectus nec ultrices luctus, odio massa euismod magna, sit amet facilisis orci felis in sem. Etiam ultrices id augue vel finibus. Fusce tortor turpis, facilisis tempus urna non, semper condimentum magna. In id nibh ac eros venenatis semper. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Lorem ipsum dolor sit amet, consectetur adipiscing elit.

Integer imperdiet mi nibh, commodo semper ante ultricies non. Aliquam blandit mauris a ex consequat ultricies. Sed blandit vestibulum gravida. Nulla fermentum enim vitae lorem tristique, ac faucibus justo fermentum. Duis fermentum, ante ut ultricies auctor, leo augue aliquam tortor, id tincidunt erat mi sit amet risus. Mauris eleifend enim quis nunc porttitor vulputate. Phasellus eu elit lacus. Donec facilisis facilisis ante, a viverra sem ultricies at."

printfn "%A" (histogram3 lipsum)
