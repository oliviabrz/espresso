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

extension GrinderDto {
    static var sampleData: [GrinderDto] {
        return [
            .init(id: 1, brandName: "Breville", modelName: "Bambino Plus"),
            .init(id: 2, brandName: "De'Longhi", modelName: "EC1000"),
            .init(id: 3, brandName: "Krups", modelName: "K1000"),
        ]
    }
}
