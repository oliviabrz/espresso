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
            GrinderListView()
                .tabItem {
                    Image(systemName: "ev.plug.ac.type.2")
                    Text("Grinder")
                }
            EspressoBeanView()  
                .tabItem {
                    Image(systemName: "cup.and.heat.waves")
                    Text("Espresso Bean")
                }
            JournalEntryView()
                .tabItem {
                    Image(systemName: "house")
                    Text("Journal Entry")
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
