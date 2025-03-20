//
//  GrinderView.swift
//  EspressoJournal
//
//  Created by Olivia Brzozowski on 2/17/25.
//

import SwiftUI
struct GrinderDetailView: View {
    @State private var grinder: GrinderDto?
    @State private var errorMessage: String?

    var body: some View {
        VStack {
            if let grinder = grinder {
                Text("Grinder: \(grinder.grinderName)")
            } else if let errorMessage = errorMessage {
                Text("Error: \(errorMessage)")
            } else {
                Text("Loading...")
                    .onAppear {
                        GrinderDataAccess().GetGrinder { result in
                            switch result {
                            case .success(let grinderDto):
                                self.grinder = grinderDto
                            case .failure(let error):
                                self.errorMessage = error.localizedDescription
                            }
                        }
                    }
            }
        }
    }
}

// sample data code
//struct GrinderView: View {
//    let grinders: [GrinderDto]
//    
//    var body: some View {
//        List(grinders, id: \.grinderName) { grinder in
//            CardView(grinder: grinder)
//            //                .listRowBackground(grinder.theme.mainColor)
//        }
//    }
//    
//    struct GrindersView_Previews: PreviewProvider {
//        static var previews: some View {
//            GrinderView(grinders: GrinderDto.sampleData)
//        }
//    }
//}

