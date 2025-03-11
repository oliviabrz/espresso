//
//  GrinderListView.swift
//  EspressoJournal
//
//  Created by Olivia Brzozowski on 3/10/25.
//
import SwiftUI
// sample data code
//struct GrinderListView: View {
//    let grinders: [GrinderDto]
//
//    var body: some View {
//        List(grinders, id: \.grinderName) { grinder in
//            CardView(grinder: grinder)
//            //                .listRowBackground(grinder.theme.mainColor)
//        }
//    }
//
//    struct GrinderListView_Previews: PreviewProvider {
//        static var previews: some View {
//            GrinderListView(grinders: GrinderDto.sampleData)
//        }
//    }
//}

struct GrinderListView: View {
    @State private var grinderList: [GrinderDto]?
    @State private var errorMessage: String?

    var body: some View {
        VStack {
            if let grinderList = grinderList {
                ForEach(grinderList, id: \.id) { grinder in
                    Text("Grinder: \(grinder.grinderName)")
                }
            } else if let errorMessage = errorMessage {
                Text("Error: \(errorMessage)")
            } else {
                Text("Loading...")
                    .onAppear {
                        GrinderDataAccess().GetGrinderList { result in
                            switch result {
                            case .success(let grinderDtoList):
                                self.grinderList = grinderDtoList
                            case .failure(let error):
                                self.errorMessage = error.localizedDescription
                            }
                        }
                    }
            }
        }
    }
}
