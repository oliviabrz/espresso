//
//  GrinderDto.swift
//  EspressoJournal
//
//  Created by Olivia Brzozowski on 2/23/25.
//

struct GrinderDto: Codable {
    var id: Int
    var brandName: String
    var modelName: String
    var grinderName: String {
        return "\(brandName.uppercased()) - \(modelName)"
    }
}

