//
//  CardView.swift
//  EspressoJournal
//
//  Created by Olivia Brzozowski on 3/1/25.
//

import SwiftUI


struct CardView: View {
    let grinder: GrinderDto
    var body: some View {
        VStack(alignment: .leading){
            Text(grinder.grinderName)
                .font(.headline)
//            Spacer()
//            HStack {
//                Label(grinder.modelName)
//            }
        }
    }
}


struct CardView_Previews: PreviewProvider {
    static var grinder = GrinderDto.sampleData[0]
    static var previews: some View {
        CardView(grinder: grinder)
//            .background(grinder.theme.mainColor)
            .previewLayout(.fixed(width: 400, height: 60))
    }
}
