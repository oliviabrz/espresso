//
//  GrinderView.swift
//  EspressoJournal
//
//  Created by Olivia Brzozowski on 2/17/25.
//

import SwiftUI

//struct GrinderView: View {
//    @State private var grinder: GrinderDto
//    @State private var viewText = "Loading..."
//
//    var body: some View {
//        Text(viewText)
//
//        GrinderDataAccess().GetGrinder { result in
//            switch result {
//            case .success(let grinderDto):
//                self.grinder = grinderDto
//
//            case .failure(let error):
//                self.viewText = "Error: \(error.localizedDescription)"
//            }
//        }
//        Text(viewText)
//    }
//}

struct GrinderView: View {
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
