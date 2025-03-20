//
//  CardBackground.swift
//  EspressoJournal
//
//  Created by Olivia Brzozowski on 3/17/25.
//

import SwiftUI

// view modifier
struct CardBackground: ViewModifier {
    func body(content: Content) -> some View {
        content
            .padding()
            .background(Color.purple)
            .cornerRadius(12)
            .shadow(radius: 8)
    }
}

// view extension for better modifier access
extension View {
    func cardBackground() -> some View {
        modifier(CardBackground())
    }
}
