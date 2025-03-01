//
//  ContentView.swift
//  EspressoJournal
//
//  Created by Olivia Brzozowski on 2/12/25.
//

import SwiftUI

struct ContentView: View {
     
    var body: some View {
        TabView{
            JournalEntryView()
                .tabItem {
                    Image(systemName: "house")
                    Text("Journal Entry")
                }
            EspressoBeanView()  
                .tabItem {
                    Image(systemName: "cup.and.heat.waves")
                    Text("Espresso Bean")
                }
            GrinderView(grinders: GrinderDto.sampleData)
                .tabItem {
                    Image(systemName: "ev.plug.ac.type.2")
                    Text("Grinder")
                }
            Text("Search")
                .tabItem {
                    Image(systemName: "magnifyingglass")
                    Text("Search")
                }
            Text("Trash")
                .tabItem {
                    Image(systemName: "trash")
                    Text("Trash")
                }
        }
    }
}

#Preview {
    ContentView()
}
